using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using geniikw.DataSheetLab;

public class UICharacterSlot : MonoBehaviour
{
    [SerializeField] private UICharacterInfo characterInfo = null;

    // name으로하면 겹침
    [SerializeField] private Text characterName = null;
    [SerializeField] private Image costBorder = null;

    public CharacterData characterData { get; set; }

    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetCharacterData(CharacterData newCharacterData)
    {
        characterData = newCharacterData;

        characterName.text = characterData.name;

        SetCostBorder(characterData.cost);
    }

    public void SetCostBorder(Cost cost)
    {
        switch (cost)
        {
            case Cost.One:
                costBorder.color = Color.gray;
                break;
            case Cost.Two:
                costBorder.color = Color.green;
                break;
            case Cost.Three:
                costBorder.color = Color.blue;
                break;
            case Cost.Four:
                costBorder.color = Color.red;
                break;
            case Cost.Five:
                costBorder.color = Color.yellow;
                break;
            default:
                Debug.Log("Error SetCostBorder");
                break;
        }
    }

    public void OnClicked()
    {
        characterInfo.SetCharacterData(characterData);
        GameManager.instance.uiManager.ShowNew(characterInfo);
    }
}
