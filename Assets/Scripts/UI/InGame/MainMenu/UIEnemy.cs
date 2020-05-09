using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using geniikw.DataSheetLab;

public class UIEnemy : MonoBehaviour
{
    [SerializeField] private UIHPBar uiHPBar = null;
    [SerializeField] private Image image = null;
    [SerializeField] private UIHitText[] uiHitTexts = null;
    public Enemy enemy { get; set; }

    public void SetEnemy(EnemyData newEnmeyData)
    {
        enemy = new Enemy();
        enemy.SetAbility(newEnmeyData.ability);
        enemy.SetName(newEnmeyData.name);

        image.sprite = newEnmeyData.image;
        enemy.OnIsDead += PlayDeadCoroutine;
        enemy.OnAttack += PlayAttackCoroutine;
        enemy.OnHit += PlayHitParticle;
        enemy.OnHit += PlayHitStateCoroutine;
        enemy.SetUIHitTexts(uiHitTexts);
        enemy.InitializeUIHitTexts();

        uiHPBar.Initialize();
        uiHPBar.UpdateHPBar();
    }

    public void OnShowUI()
    {
        image.enabled = true;
        uiHPBar.gameObject.SetActive(true);
    }

    public void PlayAttackCoroutine()
    {
        StartCoroutine(AttackCoroutine());
    }

    public void PlayHitStateCoroutine()
    {
        StartCoroutine(HitStateCoroutine());
    }

    public void PlayDeadCoroutine()
    {
        StartCoroutine(DeadCoroutine());
    }

    private IEnumerator AttackCoroutine()
    {
        gameObject.transform.Translate(new Vector3(-0.5f, 0.0f, 0.0f));
        yield return new WaitForSeconds(0.5f);
        gameObject.transform.Translate(new Vector3(0.5f, 0.0f, 0.0f));
        yield break;
    }

    private IEnumerator HitStateCoroutine()
    {
        image.color = Color.red;
        yield return new WaitForSeconds(0.4f);
        image.color = Color.white;
        yield break;
    }

    private IEnumerator DeadCoroutine()
    {
        image.enabled = false;
        yield return new WaitForSeconds(0.3f);
        image.enabled = true;
        yield return new WaitForSeconds(0.3f);
        image.enabled = false;
        yield return new WaitForSeconds(0.3f);
        image.enabled = true;
        yield return new WaitForSeconds(0.3f);
        image.enabled = false;
        uiHPBar.gameObject.SetActive(false);
        yield break;
    }

    private void PlayHitParticle()
    {
        Instantiate(GameManager.instance.particleService.hitParticle, transform);
    }
}
