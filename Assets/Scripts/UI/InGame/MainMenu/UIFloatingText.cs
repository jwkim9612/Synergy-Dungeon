using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFloatingText : MonoBehaviour
{
    [SerializeField] private Transform canvas = null;
    [SerializeField] private float moveSpeed = 0.0f;
    [SerializeField] private float duration = 0.0f;
    [SerializeField] private Text text = null;
    private Vector3 originPosition;
    private Coroutine updateCoroutine;
    bool isCoroutineRunning;

    public void Initialize()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Transform>();
        originPosition = transform.localPosition;
        isCoroutineRunning = false;
    }

    public void Play()
    {
        this.gameObject.SetActive(true);

        if(isCoroutineRunning)
        {
            StopCoroutine(updateCoroutine);
            transform.localPosition = originPosition;
        }

        updateCoroutine = StartCoroutine(UpdateText());
    }

    public void SetText(string text, Color color)
    {
        this.text.text = text;
        this.text.color = color;
    }

    public void SetText(string text)
    {
        this.text.text = text;
    }

    public void SetTextSize(int size)
    {
        text.fontSize = size;
    }

    private IEnumerator UpdateText()
    {
        isCoroutineRunning = true;

        var originParent = this.transform.parent;

        this.transform.SetParent(canvas.transform);
        float runningTime = 0.0f;

        while (true)
        {
            yield return new WaitForEndOfFrame();
            transform.Translate(new Vector3(0.0f, moveSpeed * Time.deltaTime, 0.0f));
            runningTime += Time.deltaTime;

            if (runningTime >= duration)
            {
                gameObject.SetActive(false);
                transform.SetParent(originParent);
                transform.localPosition = originPosition;
                isCoroutineRunning = false;
                StopCoroutine(updateCoroutine);
            }
        }
    }
}
