using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using geniikw.DataSheetLab;

public class UIEnemy : MonoBehaviour
{
    //private EnemyData enemyData;
    [SerializeField] private UIHPBar uiHPBar = null;
    public Enemy enemy;

    [SerializeField] private Image image = null;
    
    public void SetEnemy(EnemyData newEnmeyData)
    {
        enemy = new Enemy();
        enemy.SetAbility(newEnmeyData.ability);
        enemy.SetName(newEnmeyData.name);

        image.sprite = newEnmeyData.image;
        enemy.OnIsDead += OnHide;
        enemy.OnAttack += PlayAttackAnimation;
        enemy.OnHit += PlayHitParticle;
        enemy.OnHitForDamage += PlayFloatingText;

        uiHPBar.Initialize();
        uiHPBar.UpdateHpBar();
    }

    public void OnHide()
    {
        image.enabled = false;
    }

    public void PlayAttackAnimation()
    {
        StartCoroutine(AttackAnimation());
    }

    IEnumerator AttackAnimation()
    {
        gameObject.transform.Translate(new Vector3(-0.5f, 0.0f, 0.0f));
        yield return new WaitForSeconds(0.5f);
        gameObject.transform.Translate(new Vector3(0.5f, 0.0f, 0.0f));
    }

    private void PlayHitParticle()
    {
        Instantiate(GameManager.instance.particleService.hitParticle, transform);
    }

    private void PlayFloatingText(float damage)
    {
        var clone = Instantiate(InGameManager.instance.floatingText, transform.position, Quaternion.Euler(Vector3.zero));
        clone.GetComponent<UIFloatingText>().text.text = damage.ToString();
        clone.transform.SetParent(this.transform);
    }
}
