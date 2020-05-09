using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBehaviorMenu : MonoBehaviour
{
    [SerializeField] private Toggle attackToggle = null;
    [SerializeField] private Toggle defenseToggle = null;
    [SerializeField] private Toggle skillToggle = null;
    private Character controllingPawn;

    public void Initialize()
    {
        attackToggle.onValueChanged.AddListener((bool isOn) =>
        {
            if (isOn)
            {
                controllingPawn.SetAction(Action.Attack);
            }
        });

        defenseToggle.onValueChanged.AddListener((bool isOn) =>
        {
            if (isOn)
            {
                controllingPawn.SetAction(Action.Defense);
            }
        });

        skillToggle.onValueChanged.AddListener((bool isOn) =>
        {
            if (isOn)
            {
                controllingPawn.SetAction(Action.Skill);
            }
        });
    }

    public void SetControllingPawn(Character character)
    {
        controllingPawn = character;
    }
}
