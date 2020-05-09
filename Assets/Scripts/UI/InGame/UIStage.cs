using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStage : MonoBehaviour
{
    public Text stageText = null;

    public void Start()
    {
        StageManager.Instance.OnChangedWave += UpdateText;

        UpdateText();
    }

    public void UpdateText()
    {
        int stage = StageManager.Instance.currentStage;
        int wave = StageManager.Instance.currentWave;

        stageText.text = (stage + " - " + wave);
    }
}
