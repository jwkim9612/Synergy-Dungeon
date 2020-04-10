using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterSlot : MonoBehaviour
{
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

    public void SetName(string name)
    {
        characterName.text = name;
    }

    public void OnClicked()
    {
        Debug.Log("Clicked");
    }
}
