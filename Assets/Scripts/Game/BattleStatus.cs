using Shared.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class BattleStatus : MonoBehaviour
{
    public delegate void OnWinTheBattleDelegate();
    public OnWinTheBattleDelegate OnWinTheBattle;

    public List<Character> characters;
    public List<Enemy> enemies;

    public List<Pawn> pawnsAttackSequenceList;

    bool isCharacterAnnihilation;
    bool isEnemyAnnihilation;

    public void BattleStart()
    {
        InitializeAttackSequence();
        InitializeAnnihilation();
        InitializePawns();

        StartCoroutine(Battle());
    }

    IEnumerator Battle()
    {
        yield return new WaitForSeconds(0.5f);

        while (!isCharacterAnnihilation && !isEnemyAnnihilation)
        {
            List<Pawn> removePawnList = new List<Pawn>();

            foreach (var pawn in pawnsAttackSequenceList)
            {
                if (pawn.isDead)
                {
                    continue;
                }

                //switch(pawn.)

                Pawn target = RandomAttackAndGetTarget(pawn);
                yield return new WaitForSeconds(1.0f);
                if (target.isDead)
                {
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
            SaveManager.Instance.SetInGameData(characters, enemies);
            SaveManager.Instance.SaveInGameData();
            Debug.Log("Battle End");
            yield break;
        }
        else if (isEnemyAnnihilation)
        {
            SaveManager.Instance.SetInGameData(characters, enemies);
            SaveManager.Instance.SaveInGameData();
            OnWinTheBattle();
            Debug.Log("Battle End");
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
        pawnsAttackSequenceList = pawns.OrderBy(x => x.ability.dexterity).ToList();
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

    private int GetRandomEnemyIndex()
    {
         return RandomService.RandRange(0, enemies.Count);
    }

    private int GetRandomCharacterIndex()
    {
        return RandomService.RandRange(0, characters.Count);
    }
}
