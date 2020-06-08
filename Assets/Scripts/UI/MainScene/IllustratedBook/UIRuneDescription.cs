using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRuneDescription : MonoBehaviour
{
    [SerializeField] private Text description = null;
    [SerializeField] private ToggleGroup toggleGroup = null;

    private void Start()
    {
        SetDescription(null);
    }

    public void SetDescription(UIRune uiRune)
    {
        if(!toggleGroup.AnyTogglesOn())
        {
            description.text = "";
            return;
        }

        string runeName = uiRune.rune.runeData.Name;
        string runeDescription = uiRune.rune.runeData.Description;

        description.text = runeName + ": " + runeDescription;
    }

}
