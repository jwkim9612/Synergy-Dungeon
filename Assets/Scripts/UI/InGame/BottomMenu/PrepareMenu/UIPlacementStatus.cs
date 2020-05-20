using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlacementStatus : MonoBehaviour
{
    [SerializeField] private Text placementStatus = null;

    public void UpdatePlacementStatus()
    {
        int numOfCurrentPlacedCharacters = InGameManager.instance.draggableCentral.uiCharacterArea.numOfCurrentPlacedCharacters;
        int numOfCanBePlacedInBattleArea = InGameManager.instance.playerState.numOfCanBePlacedInBattleArea;
        Debug.Log("numOfCurrentPlacedCharacters" + numOfCurrentPlacedCharacters);
        placementStatus.text = numOfCurrentPlacedCharacters + "/" + numOfCanBePlacedInBattleArea;
    }
}
