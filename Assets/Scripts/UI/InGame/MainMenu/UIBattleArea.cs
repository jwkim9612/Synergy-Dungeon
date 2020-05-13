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
        InGameManager.instance.gameState.OnBattle += SpaceExpansion;
        InGameManager.instance.gameState.OnPrepare += SpaceReduction;
        battleStatus.OnWinTheBattle += uiCharacterArea.ShowAllUICharacters;
        battleStatus.OnWinTheBattle += InGameManager.instance.probabilityService.UpdateProbability;
        battleStatus.OnWinTheBattle += InGameManager.instance.gameState.SetIsWaveClear;
    }

    private void SpaceExpansion()
    {
        RectTransform rec = transform as RectTransform;
        rec.offsetMin = new Vector2(rec.offsetMin.x, InGameService.Size_To_Expand_The_Battle_Area);
    }

    private void SpaceReduction()
    {
        RectTransform rec = transform as RectTransform;
        rec.offsetMin = new Vector2(rec.offsetMin.x, InGameService.Size_To_Shrink_The_Battle_Area);
    }

    private void BattleStart()
    {
        battleStatus.characters = uiCharacterArea.GetCharacterList();
        battleStatus.enemies = uiEnemyArea.GetEnemyList();
        battleStatus.BattleStart();
    }

}
