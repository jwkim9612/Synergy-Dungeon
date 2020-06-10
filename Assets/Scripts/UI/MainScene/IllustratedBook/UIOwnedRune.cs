using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOwnedRune : UIRune
{
    [SerializeField] private UIEquippedRunes uiEquippedRunes = null;
    [SerializeField] private Button equipButton = null;
    [SerializeField] private GameObject clickedUIRune = null;
    [SerializeField] private Transform canvas = null;
    [SerializeField] private PotentialDraggableScrollView scrollView = null;
    public int lineIndex;

    private void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Transform>();
        scrollView = GetComponentInParent<PotentialDraggableScrollView>();
        var toggle = GetComponent<Toggle>();
        var originParent = this.transform;
        var originPosition = clickedUIRune.transform.localPosition;

        toggle.onValueChanged.AddListener((bool bOn) => 
        {
            if(bOn)
            {
                clickedUIRune.transform.localPosition = originPosition;
                clickedUIRune.SetActive(true);
                clickedUIRune.transform.parent = canvas;

                scrollView.GoToTargetByIndex(lineIndex, 4);
            }
            else
            {
                clickedUIRune.transform.parent = originParent;
                //clickedUIRune.transform.position = originPosition;
                clickedUIRune.SetActive(false);
            }
        });

        ///////////////////////////////////////////////////////////////////////////
        equipButton.onClick.AddListener(() =>
        {
            clickedUIRune.transform.parent = originParent;

            GetComponent<Toggle>().isOn = false;

            var equipResult = uiEquippedRunes.EquipRuneAndGetReplaceResult(this);
            if(equipResult.Item1)
            {
                SetUIRune(equipResult.Item2.runeData);
                uiEquippedRunes.uiOwnedRunes.AddUIRune(equipResult.Item2.runeData);
                uiEquippedRunes.uiOwnedRunes.Sort();
            }
            else
            {
                Debug.Log("교체된게 없음");
                Destroy(gameObject);
            }
        });
    }
}
