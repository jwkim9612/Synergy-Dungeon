using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWave : MonoBehaviour
{
    public Text waveText = null;

    public void Start()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        int wave = StageManager.Instance.currentWave;

        waveText.text = ("" + wave);
    }

    //void OnDestroy()
    //{
    //    StageManager.Instance.OnChangedWave -= UpdateText;
    //}
}
