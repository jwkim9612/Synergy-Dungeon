using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBattleArea : MonoBehaviour
{
    [SerializeField] private UICharacterArea uiCharacterArea = null;
    [SerializeField] private UIEnemyArea uiEnemyArea = null;
    public BattleStatus battleStatus = null;

    private void Start()
    {
        InGameManager.instance.gameState.OnBattle += BattleStart;
        InGameManager.instance.gameState.OnBattle += SpaceExpansion;
        InGameManager.instance.gameState.OnPrepare += SpaceReduction;
    }

    private void SpaceExpansion()
    {
        RectTransform rec = transform as RectTransform;
        rec.Translate(new Vector3(0.0f, -InGameService.DISTANCE_TO_MOVE_AT_START_OF_BATTLE, 0.0f));

        //RectTransform rec = transform as RectTransform;
        //rec.offsetMin = new Vector2(rec.offsetMin.x, rec.offsetMin.y + InGameService.SIZE_TO_EXPAND_THE_BATTLE_AREA * -2);

        ////uiCharacterArea.SpaceExpansion();
    }

    private void SpaceReduction()
    {
        RectTransform rec = transform as RectTransform;
        rec.Translate(new Vector3(0.0f, InGameService.DISTANCE_TO_MOVE_AT_START_OF_BATTLE, 0.0f));

        //RectTransform rec = transform as RectTransform;
        //rec.offsetMin = new Vector2(rec.offsetMin.x, rec.offsetMin.y + InGameService.SIZE_TO_EXPAND_THE_BATTLE_AREA * 2);
        
        ////uiCharacterArea.SpaceReduction();
    }

    private void BattleStart()
    {
        battleStatus.characters = uiCharacterArea.GetCharacterList();
        battleStatus.enemies = uiEnemyArea.GetEnemyList();
        battleStatus.BattleStart();
    }
}
