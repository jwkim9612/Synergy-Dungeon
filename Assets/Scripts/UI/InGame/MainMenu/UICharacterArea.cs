using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICharacterArea : MonoBehaviour
{
    public delegate void OnPlacementChangedDelegate();
    public OnPlacementChangedDelegate OnPlacementChanged { get; set; }

    public UICharacterPlacementArea frontArea;
    public UICharacterPlacementArea backArea;
    public int numOfCurrentPlacedCharacters { get; set; }

    public void Initialize()
    {
        frontArea.Initialize();
        backArea.Initialize();

        if (SaveManager.Instance.IsLoadedData)
        {
            InitializeByInGameSaveData(SaveManager.Instance.inGameSaveData.CharacterAreaInfoList);
            OnPlacementChanged();
        }
        else
        {
            numOfCurrentPlacedCharacters = 0;
        }

        InGameManager.instance.gameState.OnComplete += ShowAllUICharacters;
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

        var uiCharacterListWithCharacter = GetUICharacterListWithCharacters();
        numOfCurrentPlacedCharacters = uiCharacterListWithCharacter.Count;

        foreach(var uiCharacter in uiCharacterListWithCharacter)
        {
            uiCharacter.character.SetSize(CharacterService.SIZE_IN_BATTLE_AREA);
            uiCharacter.SetAnimationImage();
        }

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

    public void SpaceExpansion()
    {
        backArea.SpaceExpansion();
        frontArea.SpaceExpansion();
    }

    public void SpaceReduction()
    {
        backArea.SpaceReduction();
        frontArea.SpaceReduction();
    }

    public void AddCurrentPlacedCharacter()
    {
        if (numOfCurrentPlacedCharacters == InGameService.MAX_NUMBER_OF_CAN_PLACED)
            return;

        ++numOfCurrentPlacedCharacters;
        OnPlacementChanged();

    }

    public void SubCurrentPlacedCharacter()
    {
        if (numOfCurrentPlacedCharacters == InGameService.MIN_NUMBER_OF_CAN_PLACED)
            return;

        --numOfCurrentPlacedCharacters;
        OnPlacementChanged();
    }

    public void SubCurrentPlacedCharacterFromCombinations(UICharacter uiCharacter, bool isFirstCharacter)
    {
        if (isFirstCharacter)
            return;

        if (uiCharacter.GetArea<UIBattleArea>() != null)
        {
            --numOfCurrentPlacedCharacters;
            OnPlacementChanged();
        }
    }
}
