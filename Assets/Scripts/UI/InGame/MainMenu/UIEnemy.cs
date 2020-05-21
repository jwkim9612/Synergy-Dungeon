using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using geniikw.DataSheetLab;
using System.Linq;

public class UIEnemy : MonoBehaviour
{
    [SerializeField] private UIHPBar uiHPBar = null;
    [SerializeField] private List<UIFloatingText> uiFloatingTextList = null;
    public Enemy enemy;

    public void Initialize()
    {
        uiFloatingTextList = new List<UIFloatingText>();
        uiFloatingTextList = GetComponentsInChildren<UIFloatingText>(true).ToList();
    }

    public void SetEnemy(EnemyData newEnmeyData)
    {
        enemy = Instantiate(InGameService.defaultEnemy, transform.root.parent);
        enemy.SetSize(0.8f);
        enemy.SetImage(newEnmeyData.Image);
        enemy.SetAbility(newEnmeyData);
        enemy.SetName(newEnmeyData.Name);
        enemy.OnIsDead += PlayDeadCoroutine;
        enemy.OnAttack += PlayAttackCoroutine;
        enemy.OnHit += PlayHitParticle;
        enemy.OnHit += PlayShowHPBarForMoment;
        enemy.SetUIFloatingTextList(uiFloatingTextList);
        enemy.InitializeUIFloatingTextList();

        StartCoroutine(Co_PrepareFollowEnemy());
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

    public IEnumerator Co_PrepareFollowEnemy()
    {
        if (enemy != null)
        {
            yield return new WaitForEndOfFrame();
            enemy.transform.position = this.transform.position;
        }
    }

    public IEnumerator Co_FollowEnemy()
    {
        if (enemy != null)
        {
            while (true)
            {
                yield return new WaitForEndOfFrame();
                enemy.transform.position = Vector2.Lerp(enemy.transform.position, this.transform.position, 0.05f);

                if (Mathf.Abs((enemy.transform.position - this.transform.position).y) < 0.01)
                {
                    break;
                }
            }
        }

        yield break;
    }

    public void FollowEnemy()
    {
        if (enemy != null)
        {
            enemy.transform.position = this.transform.position;
        }
    }
}
