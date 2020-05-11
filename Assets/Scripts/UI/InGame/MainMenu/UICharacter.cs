using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharacter : MonoBehaviour
{
    [SerializeField] private UIHitText[] uiHitTexts = null;
    [SerializeField] private UIHPBar uiHPBar = null;
    public Character character { get; set; }
    public bool isFightingOnBattlefield { get; set; }
    public CharacterInfo characterInfo;
    public Image image = null;

    private void Start()
    {
        isFightingOnBattlefield = false;
    }

    public void SetCharacter(CharacterInfo newCharacterInfo)
    {
        OnCanClick();
        SetCharacterInfo(newCharacterInfo);

        character = new Character();
        character.SetAbility(GameManager.instance.dataSheet.characterDatas[characterInfo.id].GetAbilityDataByStar(characterInfo.star));
        character.SetName(GameManager.instance.dataSheet.characterDatas[characterInfo.id].name);
        character.OnIsDead += OnHide;
        character.OnAttack += PlayAttackCoroutine;
        character.OnHit += PlayHitParticle;
        character.OnHit += PlayHitStateCoroutine;
        character.SetUIHitTexts(uiHitTexts);
        character.InitializeUIHitTexts();

        uiHPBar.Initialize();

        InGameManager.instance.gameState.OnBattle += UpdateHPBarVisibility;
        InGameManager.instance.gameState.OnPrepare += UpdateHPBarVisibility;
    }

    public void SetCharacterInfo(CharacterInfo newCharacterInfo)
    {
        OnCanClick();
        characterInfo = newCharacterInfo;
        image.sprite = GameManager.instance.dataSheet.characterDatas[characterInfo.id].image;
    }

    public void DeleteCharacterBySell()
    {
        InGameManager.instance.playerState.IncreaseCoin(CharacterService.GetSalePrice(characterInfo));
        InGameManager.instance.stockService.AddStockId(characterInfo);
        InGameManager.instance.combinationService.SubCharacter(characterInfo);
        DeleteCharacter();
    }

    public void DeleteCharacter()
    {
        image.sprite = Resources.Load<Sprite>(CardService.DEFAULT_IMAGE_NAME);

        character = null;
        InGameManager.instance.gameState.OnBattle -= UpdateHPBarVisibility;
        InGameManager.instance.gameState.OnPrepare -= UpdateHPBarVisibility;

        characterInfo.id = -1;
        characterInfo.star = 0;

        OnCanNotClick();
    }

    public void UpgradeStar()
    {
        ++characterInfo.star;
        InGameManager.instance.combinationService.AddCharacter(characterInfo);
        Instantiate(GameManager.instance.particleService.upgradeParticle, transform);
        // 파티클 재생 함수
    }

    public void OnCanClick()
    {
        image.raycastTarget = true;
    }

    public void OnCanNotClick()
    {
        image.raycastTarget = false;
    }

    public void OnHide()
    {
        this.gameObject.SetActive(false);
    }

    public void PlayAttackCoroutine()
    {
        StartCoroutine(AttackCoroutine());
    }

    public void PlayHitStateCoroutine()
    {
        StartCoroutine(HitStateCoroutine());
    }

    private IEnumerator AttackCoroutine()
    {
        gameObject.transform.Translate(new Vector3(0.5f, 0.0f, 0.0f));
        yield return new WaitForSeconds(0.5f);
        gameObject.transform.Translate(new Vector3(-0.5f, 0.0f, 0.0f));
        yield break;
    }

    private IEnumerator HitStateCoroutine()
    {
        image.color = Color.red;
        yield return new WaitForSeconds(0.4f);
        image.color = Color.white;
        yield break;
    }

    private void PlayHitParticle()
    {
        Instantiate(GameManager.instance.particleService.hitParticle, transform);
    }

    private void UpdateHPBarVisibility()
    {
        if(isFightingOnBattlefield)
        {
            uiHPBar.OnShow();
        }
        else
        {
            uiHPBar.OnHide();
        }
    }
}
