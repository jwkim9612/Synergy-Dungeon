using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBattleArea : MonoBehaviour
{
    [SerializeField] private UICharacterArea uiCharacterArea = null;
    [SerializeField] private UIEnemyArea uiEnemyArea = null;
    [SerializeField] private BattleStatus battleStatus = null;

    private void Start()
    {
        InGameManager.instance.gameState.OnBattle += BattleStart;
        battleStatus.OnWinTheBattle += uiCharacterArea.ShowAllUICharacters;
        battleStatus.OnWinTheBattle += InGameManager.instance.probabilityService.UpdateProbability;
        battleStatus.OnWinTheBattle += InGameManager.instance.gameState.SetIsWaveClear;
    }

    private void BattleStart()
    {
        battleStatus.characters = uiCharacterArea.GetCharacterList();
        battleStatus.enemies = uiEnemyArea.GetEnemyList();
        battleStatus.BattleStart();
    }

}
