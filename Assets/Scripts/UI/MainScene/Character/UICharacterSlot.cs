using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using geniikw.DataSheetLab;

public class UICharacterSlot : MonoBehaviour
{
    [SerializeField] private UICharacterInfo characterInfo = null;

    [SerializeField] private Image character = null;
    // name으로하면 겹침
    [SerializeField] private Text characterName = null;
    [SerializeField] private Text Upgrade = null;
    [SerializeField] private Image tribe = null;
    [SerializeField] private Image origin = null;

    private CharacterData characterData;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetCharacterData(CharacterData newCharacterData)
    {
        characterData = newCharacterData;

        characterName.text = characterData.name;
    }

    public void OnClicked()
    {
        characterInfo.SetCharacterData(characterData);
        GameManager.instance.uiManager.ShowNew(characterInfo);
    }
}
