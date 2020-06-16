﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInGameCheat : MonoBehaviour
{
    public UICharacterPurchase uiCharacterPurchase;
    public Button purchaseCharacterButton;
    public InputField purchaseCharacterInputField;

    public PlayerState playerState;
    public Button addCoinButton;

    private void Start()
    {
        purchaseCharacterButton.onClick.AddListener(() =>
        {
            int id;
            bool isNum = int.TryParse(purchaseCharacterInputField.text, out id);

            if (isNum)
            {
                if (!IsBetweenCharacterID(id))
                    return;

                uiCharacterPurchase.CheatPurchaseCharacter(id);
            }
            else
            {
                Debug.Log("숫자를 입력하세요.");
            }
        });

        addCoinButton.onClick.AddListener(() =>
        {
            playerState.IncreaseCoin(100);
        });
    }

    private bool IsBetweenCharacterID(int id)
    {
        return (id <= CharacterService.ID_OF_LAST_CHARACTER && id >= CharacterService.ID_OF_FIRST_CHARACTER) ? true : false;
    }
}
