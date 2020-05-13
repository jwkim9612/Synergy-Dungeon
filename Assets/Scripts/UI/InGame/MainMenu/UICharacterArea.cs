using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICharacterArea : MonoBehaviour
{
    public UIPlacementArea backArea;
    public UIPlacementArea frontArea;

    private void Start()
    {
        if (SaveManager.Instance.HasInGameData())
        {
            InitializeByInGameSaveData(SaveManager.Instance.inGameSaveData.characterAreaInfoList);
        }
    }

    public bool IsEmpty()
    {
        return backArea.IsEmpty() && frontArea.IsEmpty() ? true : false;
    }

    public List<CharacterInfo> GetAllCharacterInfo()
    {
        List<CharacterInfo> characterInfoList = new List<CharacterInfo>();

        foreach (var uiCharacter in backArea.uiCharacters)
        {
            characterInfoList.Add(uiCharacter.characterInfo);
        }

        foreach (var uiCharacter in frontArea.uiCharacters)
        {
            characterInfoList.Add(uiCharacter.characterInfo);
        }

        return characterInfoList;
    }

    protected void InitializeByInGameSaveData(List<CharacterInfo> characterInfoList)
    {
        List<CharacterInfo> backAreaInfos = characterInfoList.GetRange(0, InGameService.NUMBER_OF_BACKAREA);
        List<CharacterInfo> frontAreaInfos = characterInfoList.GetRange(InGameService.NUMBER_OF_BACKAREA, InGameService.NUMBER_OF_FRONTAREA);

        backArea.InitializeByInGameSaveData(backAreaInfos);
        frontArea.InitializeByInGameSaveData(frontAreaInfos);
    }

    public void ShowAllUICharacters()
    {
        backArea.ShowAllUICharacters();
        frontArea.ShowAllUICharacters();
    }

    public List<Character> GetCharacterList()
    {
        List<Character> characters = new List<Character>();

        var backAreaCharacterList = backArea.GetCharacterList();
        var frontAreaCharacterList = frontArea.GetCharacterList();

        if (backAreaCharacterList != null)
        {
            characters.AddRange(backArea.GetCharacterList());
        }

        if (frontAreaCharacterList != null)
        {
            characters.AddRange(frontArea.GetCharacterList());
        }

        if (characters.Count == 0)
        {
            return null;
        }

        return characters;
    }

    public List<UICharacter> GetUICharacterListWithCharacters()
    {
        List<UICharacter> uiCharacters = new List<UICharacter>();

        uiCharacters.AddRange(backArea.GetUICharacterListWithCharacters());
        uiCharacters.AddRange(frontArea.GetUICharacterListWithCharacters());

        return uiCharacters;
    }
}
