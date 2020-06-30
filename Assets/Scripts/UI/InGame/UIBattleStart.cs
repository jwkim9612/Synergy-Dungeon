using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBattleStart : MonoBehaviour
{
    [SerializeField] private Text textBattleStart;

    private float defaultSize;
    void Start()
    {
        defaultSize = 60.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAnimation()
    {
        StartCoroutine(Co_PlayAnimation());
    }

    private IEnumerator Co_PlayAnimation()
    {
        float time = 2.0f;
        textBattleStart.transform.localScale = Vector3.one * (defaultSize - time);
        if(time > 1f)
        {
            time = 0;
            
        }

        yield return new WaitForEndOfFrame();
    }
}
