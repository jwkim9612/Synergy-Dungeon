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
        enemy.Initialize();
        enemy.SetSize(0.8f);
        enemy.SetImage(newEnmeyData.Image);
        enemy.SetAbility(newEnmeyData);
        enemy.SetName(newEnmeyData.Name);
        enemy.OnHit += PlayHitParticle;
        enemy.OnHit += PlayShowHPBarForMoment;
        enemy.SetUIFloatingTextList(uiFloatingTextList);
        enemy.InitializeUIFloatingTextList();

        StartCoroutine(Co_PrepareFollowEnemy());
        uiHPBar.Initialize();
        uiHPBar.UpdateHPBar();
    }

    public void PlayShowHPBarForMoment()
    {
        StartCoroutine(Co_ShowHPBarForMoment());
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

                var positionToMove = Vector2.Lerp(enemy.transform.position, this.transform.position, 0.05f);
                enemy.transform.position = new Vector3(positionToMove.x, positionToMove.y, InGameService.Z_VALUE_OF_PAWN);

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
