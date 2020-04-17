using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICharacterPurchase : MonoBehaviour
{
    const int NumOfCards = 29;

    [SerializeField] private UICharacterCard[] card = null;

    void Start()
    {
        card[0].SetCard(GameManager.instance.playerDataManager.characterDatas[0]);
        card[1].SetCard(GameManager.instance.playerDataManager.characterDatas[1]);
        card[2].SetCard(GameManager.instance.playerDataManager.characterDatas[2]);
        card[3].SetCard(GameManager.instance.playerDataManager.characterDatas[3]);
    }

    public void Shuffle()
    {
        for(int i = 0; i < 4; ++i)
        {
            int index = Random.Range(0, NumOfCards - 1);
            card[i].SetCard(GameManager.instance.playerDataManager.characterDatas[index]);
        }
    }
}
