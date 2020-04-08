using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainOption : UIControl
{
    [SerializeField] private Slider bgmSoundSlider = null;
    [SerializeField] private Slider effectSoundSlider = null;

    void Start()
    {
        bgmSoundSlider.value = PlayerPrefs.GetInt("BGMSound");
        effectSoundSlider.value = PlayerPrefs.GetInt("EffectSound");
    }

    public void OnBGMSoundValueChanged()
    {
        PlayerPrefs.SetInt("BGMSound", (int)bgmSoundSlider.value);
    }

    public void OnEffectSoundValueChanged()
    {
        PlayerPrefs.SetInt("EffectSound", (int)effectSoundSlider.value);
    }
}
