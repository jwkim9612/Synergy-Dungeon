using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using geniikw.DataSheetLab;

public class UIEnemy : MonoBehaviour
{
    [SerializeField] private UIHPBar uiHPBar = null;
    [SerializeField] private UIHitText[] uiHitTexts = null;
    public Enemy enemy;

    public void SetEnemy(EnemyData newEnmeyData)
    {
        enemy = Instantiate(InGameService.defaultEnemy, transform.root.parent);
        enemy.SetSize(0.8f);
        enemy.SetImage(newEnmeyData.image);
        enemy.SetAbility(newEnmeyData.ability);
        enemy.SetName(newEnmeyData.name);

        enemy.OnIsDead += PlayDeadCoroutine;
        enemy.OnAttack += PlayAttackCoroutine;
        enemy.OnHit += PlayHitParticle;
        enemy.OnHit += PlayShowHPBarForMoment;
        enemy.SetUIHitTexts(uiHitTexts);
        enemy.InitializeUIHitTexts();

        StartCoroutine(Co_FollowEnemy());
        uiHPBar.Initialize();
        uiHPBar.UpdateHPBar();
    }

    public void PlayAttackCoroutine()
    {
        StartCoroutine(AttackCoroutine());
    }

    public void PlayDeadCoroutine()
    {
        StartCoroutine(DeadCoroutine());
    }

    public void PlayShowHPBarForMoment()
    {
        StartCoroutine(Co_ShowHPBarForMoment());
    }

    private IEnumerator AttackCoroutine()
    {
        gameObject.transform.Translate(new Vector3(-0.5f, 0.0f, 0.0f));
        yield return new WaitForSeconds(0.5f);
        gameObject.transform.Translate(new Vector3(0.5f, 0.0f, 0.0f));
        yield break;
    }

    private IEnumerator DeadCoroutine()
    {
        //image.enabled = false;
        yield return new WaitForSeconds(0.3f);
        //image.enabled = true;
        yield return new WaitForSeconds(0.3f);
        //image.enabled = false;
        yield return new WaitForSeconds(0.3f);
        //image.enabled = true;
        yield return new WaitForSeconds(0.3f);
        //image.enabled = false;
        enemy.DestoryPawn();
        uiHPBar.gameObject.SetActive(false);
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

    public IEnumerator Co_FollowEnemy()
    {
        if (enemy != null)
        {
            yield return new WaitForEndOfFrame();
            enemy.transform.position = this.transform.position;
        }
    }

    public void FollowEnemy()
    {
        if (enemy != null)
        {
            enemy.transform.position = this.transform.position;
        }
    }

    void OnDestroy()
    {
    }
}
