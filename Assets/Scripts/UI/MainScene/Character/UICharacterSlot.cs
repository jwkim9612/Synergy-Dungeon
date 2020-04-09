using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterSlot : MonoBehaviour
{
    [SerializeField] private GameObject chararcterSlot = null;

    [SerializeField] private Image character = null;
    // name으로하면 겹침
    [SerializeField] private Text characterName = null;
    [SerializeField] private Text Upgrade = null;
    [SerializeField] private Image tribe = null;
    [SerializeField] private Image origin = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void setName(string name)
    {
        characterName.text = name;
    }

    public void SetActive(bool Value)
    {
        chararcterSlot.SetActive(Value);
    }
}
