using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIBattleMenu : MonoBehaviour
{
    private UICharacterStatuses[] uiCharacterStatusesList;

    public void Initialize()
    {
        uiCharacterStatusesList = GetComponentsInChildren<UICharacterStatuses>();

        foreach(var uiCharacterStatuses in uiCharacterStatusesList)
        {
            uiCharacterStatuses.Initialize();
        }

        InGameManager.instance.gameState.OnBattle += InitializeCharacterStatusList;
    }

    public void OnShow()
    {
        this.gameObject.SetActive(true);
    }

    public void OnHide()
    {
        this.gameObject.SetActive(false);
    }

    public void InitializeCharacterStatusList()
    {
        var uiCharacterList = InGameManager.instance.draggableCentral.uiCharacterArea.GetUICharacterListWithCharacters();

        int characterIndex = 0;

        for(int statusesIndex = 0; statusesIndex < uiCharacterStatusesList.Length; ++statusesIndex)
        {
            for(int statusIndex = 0; statusIndex < uiCharacterStatusesList[statusesIndex].characterStatusList.Length; ++statusIndex)
            {
                if(uiCharacterList.Count > characterIndex)
                {
                    uiCharacterStatusesList[statusesIndex].characterStatusList[statusIndex].SetCharacterStatus(uiCharacterList[characterIndex]);
                }
                else
                {
                    uiCharacterStatusesList[statusesIndex].characterStatusList[statusIndex].HideAll();
                }

                ++characterIndex;
            }
        }
    }
}
