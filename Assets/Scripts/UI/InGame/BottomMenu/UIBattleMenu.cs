using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIBattleMenu : MonoBehaviour
{
    [SerializeField] private UICharacterArea uiCharacterArea = null;
    private UICharacterStatus[] characterStatusList = null;

    public void Initialize()
    {
        characterStatusList = gameObject.GetComponentsInChildren<UICharacterStatus>();
        InGameManager.instance.gameState.OnBattle += InitializeCharacterStatusList;

        foreach(var characterStatus in characterStatusList)
        {
            characterStatus.Initialize();
        }
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
        var uiCharacterList = uiCharacterArea.GetUICharacterListWithCharacters();

        for(int i = 0; i < characterStatusList.Count(); ++i)
        {
            if(uiCharacterList.Count > i)
            {
                characterStatusList[i].gameObject.SetActive(true);
                characterStatusList[i].SetCharacterStatus(uiCharacterList[i]);
            }
            else
            {
                characterStatusList[i].gameObject.SetActive(false);
            }
        }
    }
}
