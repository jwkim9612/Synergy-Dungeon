using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public void Initialize()
    {
        if(!PlayerPrefs.HasKey("BGMSound") || !PlayerPrefs.HasKey("EffectSound"))
        {
            PlayerPrefs.SetInt("BGMSound", 100);
            PlayerPrefs.SetInt("EffectSound", 100);
        }

        // Sound On 함수
    }

    public void UpdateBgmSound()
    {
        // bgm 소리 크기 변경
    }

    public void UpdateEffectSound()
    {
        // effect 소리 크기 변경
    }
}
