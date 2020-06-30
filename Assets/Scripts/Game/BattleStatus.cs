using Shared.Service;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleStatus : MonoBehaviour
{
    public delegate void OnWinTheBattleDelegate();
    public OnWinTheBattleDelegate OnWinTheBattle { get; set; }

    [SerializeField] private UIBattleStart uiBattleStart;

    public List<Character> characters { get; set; }
    public List<Enemy> enemies { get; set; }
    public List<Pawn> pawnsAttackSequenceList { get; set; }

    private bool isCharacterAnnihilation;
    private bool isEnemyAnnihilation;

    public void BattleStart()
    {
        InitializeAttackSequence();
        InitializeAnnihilation();
        InitializePawns();

        StartCoroutine(Battle());
    }

    private IEnumerator Battle()
    {
        Debug.Log("Battle");

        if (characters.Count == 0)
            isCharacterAnnihilation = true;

        uiBattleStart.gameObject.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        uiBattleStart.gameObject.SetActive(false);

        while (!isCharacterAnnihilation && !isEnemyAnnihilation)
        {
            List<Pawn> removePawnList = new List<Pawn>();

            foreach (var pawn in pawnsAttackSequenceList)
            {
                if (pawn.isDead)
                {
                    continue;
                }

                if(pawn is Character)
                {
                    // 애니메이션 다 생기면 없앰.
                    Character character = pawn as Character;
                    if (character.HasAnimation())
                    {
                        character.PlayAttackAnimation();
                    }
                    else
                    {
                        character.RandomAttack();
                    }
                    // Character의 애니메이션 안에 RandomAttack이 있음
                }
                else
                {
                    pawn.RandomAttack();
                }

                float attackAnimationLength = pawn.GetAttackAnimationLength();
                yield return new WaitForSeconds(attackAnimationLength + 0.5f);

                Pawn target = pawn.GetTarget();

                if (target.isDead)
                {
                    yield return new WaitForSeconds(1.0f);
                    RemoveFromAttackList(target);
                    removePawnList.Add(target);

                    if (characters.Count == 0)
                    {
                        isCharacterAnnihilation = true;
                        break;
                    }
                    else if (enemies.Count == 0)
                    {
                        isEnemyAnnihilation = true;
                        break;
                    }
                }
            }

            pawnsAttackSequenceList.RemoveAll(removePawnList.Contains);
        }

        // 배틀 종료 
        if (isCharacterAnnihilation)
        {
            SaveManager.Instance.RemoveInGameData();
            InGameManager.instance.gameState.isPlayerLose = true;
            Debug.Log("Battle End");
            yield break;
        }
        else if (isEnemyAnnihilation)
        {
            AllCharactersPlayWinAnimation();

            if (StageManager.Instance.IsFinalWave())
            {
                SaveManager.Instance.RemoveInGameData();
                Debug.Log("데이터 삭제!");
            }
            else
            {
                SaveManager.Instance.SetInGameData();
                SaveManager.Instance.SaveInGameData();
            }

            yield return new WaitForSeconds(3.0f);

            OnWinTheBattle();
            yield break;
        }
        else
        {
            Debug.Log("Error Battle End");
        }
    }

    /// <summary>
    /// 공격 순서 초기화
    /// </summary>
    private void InitializeAttackSequence()
    {
        List<Pawn> pawns = new List<Pawn>();
        pawns.AddRange(characters);
        pawns.AddRange(enemies);

        pawnsAttackSequenceList = pawns.OrderBy(x => x.ability.AttackSpeed).ToList();
    }

    private void InitializeAnnihilation()
    {
        isCharacterAnnihilation = false;
        isEnemyAnnihilation = false;
    }

    private void InitializePawns()
    {
        foreach (var pawn in pawnsAttackSequenceList)
        {
            pawn.ResetStat();
        }
    }

    /// <summary>
    /// 어떤 타입의 폰인지 확인하고 공격해야 할 폰을 
    /// 찾은 후 공격한다.
    /// </summary>
    /// <param name="pawn"> 공격하는 폰 </param>
    /// <returns> 타겟 </returns>
    private Pawn RandomAttackAndGetTarget(Pawn pawn)
    {
        // 공격하는 폰이 캐릭터인 경우
        if (IsCharacter(pawn))
        {
            int enemyIndex = GetRandomEnemyIndex();
            pawn.Attack(enemies[enemyIndex]);
            return enemies[enemyIndex];
        }
        else
        {
            int characterIndex = GetRandomCharacterIndex();
            pawn.Attack(characters[characterIndex]);
            return characters[characterIndex];
        }
    }

    /// <summary>
    /// 폰을 리스트에서 삭제함
    /// </summary>
    /// <param name="pawn"> 지워줄 폰 </param>
    private void RemoveFromAttackList(Pawn pawn)
    {
        if (IsCharacter(pawn))
        {
            characters.Remove(pawn as Character);
        }
        else
        {
            enemies.Remove(pawn as Enemy);
        }
    }

    private bool IsCharacter(Pawn pawn)
    {
        return pawn.pawnType == PawnType.Character;
    }

    public Enemy GetRandomEnemy()
    {
        int enemiesRandomIndex = GetRandomEnemyIndex();
        return enemies[enemiesRandomIndex];
    }

    public Character GetRandomCharacter()
    {
        int charactersRandomIndex = GetRandomCharacterIndex();
        return characters[charactersRandomIndex];
    }

    private int GetRandomEnemyIndex()
    {
        if (enemies.Count <= 0)
        {
            Debug.LogError("Error GetRandomEnemyIndex");
            return -1;
        }

        return RandomService.RandRange(0, enemies.Count);
    }

    private int GetRandomCharacterIndex()
    {
        if (characters.Count <= 0)
        {
            Debug.LogError("Error GetRandomCharacterIndex");
            return -1;
        }

        return RandomService.RandRange(0, characters.Count);
    }

    private void AllCharactersPlayWinAnimation()
    {
        for (int i = 0; i < characters.Count; ++i)
        {
            characters[i].PlayWinAnimation();
        }
    }
}
