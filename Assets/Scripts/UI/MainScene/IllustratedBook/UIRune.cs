using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRune : MonoBehaviour
{
    [SerializeField] private Image image;
    private Rune rune;

    public void SetRune()
    {
        rune = new Rune();
        rune.SetRuneData();

        // 이미지 넣어주기.
    }
}
