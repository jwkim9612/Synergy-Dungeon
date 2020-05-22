using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UICharacter : MonoBehaviour
{
    [SerializeField] private List<UIFloatingText> uiFloatingTextList = null;
    [SerializeField] private UIHPBar uiHPBar = null;
    public Character character;
    public bool isFightingOnBattlefield { get; set; }
    public CharacterInfo characterInfo;
    public Image clickableImage = null;

    public void Initialize()
    {
        isFightingOnBattlefield = false;

        uiFloatingTextList = new List<UIFloatingText>();
        uiFloatingTextList = GetComponentsInChildren<UIFloatingText>(true).ToList();
    }

    public void SetCharacter(CharacterInfo newCharacterInfo)
    {
        OnCanClick();
        SetCharacterInfo(newCharacterInfo);

        character = Instantiate(InGameService.defaultCharacter, transform.root.parent);
        character.SetSize(0.5f);
        character.SetImage(GameManager.instance.dataSheet.characterDataSheet.characterDatas[characterInfo.id].Image);
        character.SetAbility(GameManager.instance.dataSheet.characterAbilityDataSheet.GetAbilityDataByStar(characterInfo));
        character.SetName(GameManager.instance.dataSheet.characterDataSheet.characterDatas[characterInfo.id].Name);
        character.OnIsDead += OnHide;
        character.OnAttack += PlayAttackCoroutine;
        character.OnHit += PlayHitParticle;
        character.OnHit += PlayShowHPBarForMoment;
        character.SetUIFloatingTextList(uiFloatingTextList);
        character.InitializeUIFloatingTextList();

        StartCoroutine(Co_PrepareFollowCharacter());
        uiHPBar.Initialize();
    }

    public void SetCharacterInfo(CharacterInfo newCharacterInfo)
    {
        characterInfo = newCharacterInfo;
    }

    public CharacterInfo DeleteCharacterBySell()
    {
        CharacterInfo deletedCharacterInfo = characterInfo;

        InGameManager.instance.playerState.IncreaseCoin(CharacterService.GetSalePrice(characterInfo));
        InGameManager.instance.stockService.AddStockId(characterInfo);
        InGameManager.instance.combinationService.SubCharacter(characterInfo);
        DeleteCharacter();

        return deletedCharacterInfo;
    }

    public void DeleteCharacter()
    {
        character.DestoryPawn();
        character = null;

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
        clickableImage.raycastTarget = true;
    }

    public void OnCanNotClick()
    {
        clickableImage.raycastTarget = false;
    }

    public void OnHide()
    {
        this.gameObject.SetActive(false);
    }

    public void PlayAttackCoroutine()
    {
        StartCoroutine(Co_AttackAnimation());
    }

    public void PlayShowHPBarForMoment()
    {
        StartCoroutine(Co_ShowHPBarForMoment());
    }

    private IEnumerator Co_AttackAnimation()
    {
        gameObject.transform.Translate(new Vector3(0.5f, 0.0f, 0.0f));
        yield return new WaitForSeconds(0.5f);
        gameObject.transform.Translate(new Vector3(-0.5f, 0.0f, 0.0f));
        yield break;
    }

    private IEnumerator Co_ShowHPBarForMoment()
    {
        uiHPBar.OnShow();
        yield return new WaitForSeconds(1.5f);
        uiHPBar.OnHide();
        yield break;
    }

    private void PlayHitParticle()
    {
        Instantiate(GameManager.instance.particleService.hitParticle, transform);
    }

    public T GetArea<T>()
    {
        return this.GetComponentInParent<UISlot>().GetComponentInParent<T>();
    }

    public IEnumerator Co_PrepareFollowCharacter()
    {
        if (character != null)
        {
            yield return new WaitForEndOfFrame();
            character.transform.position = this.transform.position;
        }
    }

    public IEnumerator Co_FollowCharacter()
    {
        if (character != null)
        {
            while(true)
            {
                yield return new WaitForEndOfFrame();
                character.transform.position = Vector2.Lerp(character.transform.position, this.transform.position, 0.05f);

                if(Mathf.Abs((character.transform.position - this.transform.position).y) < 0.01 )
                {
                    break;
                }
            }
        }
    }

    public void FollowCharacter()
    {
        if (character != null)
        {
            character.transform.position = this.transform.position;
        }
    }
}
