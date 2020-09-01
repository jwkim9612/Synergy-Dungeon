using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIStageClear : MonoBehaviour
{
    [SerializeField] private Button backToMenuButton = null;
    [SerializeField] private Text levelText = null;
    [SerializeField] private Slider expSlider = null;

    public void Initialize()
    {
        backToMenuButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("MainScene");
        });
    }

    public void SetLevel(int level)
    {
        levelText.text = level.ToString();
    }

    public void SetExp()
    {
        var playerState = InGameManager.instance.playerState;
        var level = playerState.level;
        var exp = playerState.exp;

        if(DataBase.Instance.playerExpDataSheet.TryGetSatisfyExp(level, out var satisfyExp))
        {
            expSlider.value = (float)exp / satisfyExp;
        }
    }

    public void OnShow()
    {
        gameObject.SetActive(true);
    }

    public void OnHide()
    {
        gameObject.SetActive(false);
    }
}
