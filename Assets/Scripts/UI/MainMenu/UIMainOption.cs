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

    }

    public void OnBGMSoundValueChanged()
    {
        PlayerPrefs.SetInt("BGMSound", (int)bgmSoundSlider.value);
        GameManager.instance.soundManager.UpdateBgmSound();
    }

    public void OnEffectSoundValueChanged()
    {
        PlayerPrefs.SetInt("EffectSound", (int)effectSoundSlider.value);
        GameManager.instance.soundManager.UpdateEffectSound();
    }
}
