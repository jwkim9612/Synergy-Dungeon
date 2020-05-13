using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWave : MonoBehaviour
{
    public Text waveText = null;

    public void Start()
    {
        StageManager.Instance.OnChangedWave += UpdateText;

        UpdateText();
    }

    public void UpdateText()
    {
        //int stage = StageManager.Instance.currentStage;
        int wave = StageManager.Instance.currentWave;

        waveText.text = ("" + wave);
    }
}
