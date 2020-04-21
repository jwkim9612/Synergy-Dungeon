using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStage : MonoBehaviour
{
    public Text stageText = null;
    public StageManager stageManager;

    public void Start()
    {
        stageManager = GameManager.instance.stageManager;

        UpdateText();
    }

    public void UpdateText()
    {
        int stage = stageManager.currentStage;
        int wave = stageManager.currentWave;

        stageText.text = (stage + " - " + wave);
    }
}
