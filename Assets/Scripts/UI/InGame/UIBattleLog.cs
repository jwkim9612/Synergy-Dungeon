using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class UIBattleLog : MonoBehaviour
{
    [SerializeField] private Text logText;
    [SerializeField] private RectTransform logRect;

    [SerializeField] private float anchorMaxY = 0.8f;
    [SerializeField] private float anchorMinY = 0.6f;
    
    private bool activeLogRect = false;
    private StringBuilder battleLog = new StringBuilder();

    public void OnClickToggleLogText()
    {
        activeLogRect = !activeLogRect;

        float curAnchor = activeLogRect ? anchorMinY : anchorMaxY;

        logRect.anchorMin = new Vector2(0.0f, curAnchor);
    }

    public void AddBattleLog(string log)
    {
        battleLog.Append("\n");
        battleLog.Append(log);
        logText.text = battleLog.ToString();
    }
}
