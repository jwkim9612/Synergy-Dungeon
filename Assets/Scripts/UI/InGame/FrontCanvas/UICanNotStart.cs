using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UICanNotStart : MonoBehaviour
{
    [SerializeField] private Text canNotStartText = null;
    
    private Coroutine showCanNotStartCoroutine;

    public void PlayShowCanNotStart()
    {
        if (IsPlaying())
        {
            StopCoroutine(showCanNotStartCoroutine);
        }

        showCanNotStartCoroutine = StartCoroutine(Co_PlayShowCanNotStart());
    }

    public void HideCanNotStart()
    {
        if (IsPlaying())
        {
            StopCoroutine(showCanNotStartCoroutine);
            ShowCanNotStartText();
        }
    }

    private IEnumerator Co_PlayShowCanNotStart()
    {
        ShowCanNotStartText();
        yield return new WaitForSeconds(2.0f);
        HideCanNotStartText();
        yield break;
    }

    private bool IsPlaying()
    {
        return gameObject.activeSelf? true : false;
    }

    private void ShowCanNotStartText()
    {
        canNotStartText.gameObject.SetActive(true);
    }

    private void HideCanNotStartText()
    {
        canNotStartText.gameObject.SetActive(false);
    }
}
