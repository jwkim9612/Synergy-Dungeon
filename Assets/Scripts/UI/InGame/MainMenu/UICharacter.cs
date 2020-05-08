using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharacter : MonoBehaviour
{
    public Character character;
    public bool isFightingOnBattlefield;

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
        character.OnAttack += PlayAttackAnimation;
        character.OnHit += PlayHitParticle;
        character.OnHitForDamage += PlayFloatingText;
    }

    public void SetCharacterInfo(CharacterInfo newCharacterInfo)
    {
        OnCanClick();
        characterInfo = newCharacterInfo;
        image.sprite = GameManager.instance.dataSheet.characterDatas[characterInfo.id].image;
    }

    public void DeleteCharacterBySell()
    {
        InGameManager.instance.stockService.AddStockId(characterInfo);
        InGameManager.instance.combinationService.SubCharacter(characterInfo);
        DeleteCharacter();
    }

    public void DeleteCharacter()
    {
        image.sprite = Resources.Load<Sprite>(CardService.DEFAULT_IMAGE_NAME);

        //characterInfo = null;
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

    public void PlayAttackAnimation()
    {
        StartCoroutine(AttackAnimation());
    }

    IEnumerator AttackAnimation()
    {
        gameObject.transform.Translate(new Vector3(0.5f, 0.0f, 0.0f));
        yield return new WaitForSeconds(0.5f);
        gameObject.transform.Translate(new Vector3(-0.5f, 0.0f, 0.0f));
    }

    private void PlayHitParticle()
    {
        Instantiate(GameManager.instance.particleService.hitParticle, transform);
    }

    private void PlayFloatingText(float damage)
    {
        var clone = Instantiate(InGameManager.instance.floatingText, transform.localPosition, Quaternion.Euler(Vector3.zero));
        clone.transform.SetParent(this.transform);
        clone.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        clone.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        clone.GetComponent<UIFloatingText>().text.text = damage.ToString();
    }
}
