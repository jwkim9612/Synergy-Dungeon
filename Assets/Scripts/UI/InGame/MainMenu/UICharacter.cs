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

    private CharacterDataSheet characterDataSheet;

    public void Initialize()
    {
        isFightingOnBattlefield = false;

        uiFloatingTextList = new List<UIFloatingText>();
        uiFloatingTextList = GetComponentsInChildren<UIFloatingText>(true).ToList();

        characterDataSheet = DataBase.Instance.characterDataSheet;
        if(characterDataSheet == null)
        {
            Debug.LogError("Error characterDataSheet is null");
        }
    }

    public void SetCharacter(CharacterInfo newCharacterInfo)
    {
        OnCanClick();
        SetCharacterInfo(newCharacterInfo);

        if (characterDataSheet == null)
        {
            Debug.LogError("Error characterDataSheet is null");
            return;
        }

        character = Instantiate(InGameService.defaultCharacter, transform.root.parent);
        character.Initialize();

        if(characterDataSheet.TryGetCharacterImage(characterInfo.id, out var sprite))
        {
            character.SetImage(sprite);
        }
        if (characterDataSheet.TryGetCharacterName(characterInfo.id, out var name))
        {
            character.SetName(name);
        }
        if (characterDataSheet.TryGetCharacterOrigin(characterInfo.id, out var origin))
        {
            character.SetAbility(DataBase.Instance.characterAbilityDataSheet.GetAbilityDataByStar(characterInfo), origin);
        }

        character.OnIsDead += OnHide;
        character.OnHit += PlayHitParticle;
        character.OnHit += PlayShowHPBarForMoment;
        character.SetUIFloatingTextList(uiFloatingTextList);
        character.InitializeUIFloatingTextList();

        StartCoroutine(Co_PrepareFollowCharacter());
        uiHPBar.Initialize();
    }

    public void SetDefaultImage()
    {
        if (characterDataSheet == null)
        {
            Debug.LogError("Error characterDataSheet is null");
            return;
        }

        if (characterDataSheet.TryGetCharacterImage(characterInfo.id, out var sprite))
        {
            character.RemoveRunTimeAnimatorController();
            character.SetImage(sprite);
        }
    }

    public void SetAnimationImage()
    {
        if (characterDataSheet == null)
        {
            Debug.LogError("Error characterDataSheet is null");
            return;
        }

        if (characterDataSheet.TryGetCharacterRunTimeAnimatorController(characterInfo.id, out var runTimeAnimatorController))
        {
            character.SetRunTimeAnimatorController(runTimeAnimatorController);
        }
    }

    public void SetCharacterInfo(CharacterInfo newCharacterInfo)
    {
        characterInfo = newCharacterInfo;
    }

    public CharacterInfo DeleteCharacterBySell()
    {
        CharacterInfo deletedCharacterInfo = characterInfo;

        InGameManager.instance.playerState.IncreaseCoin(CharacterService.GetSalePrice(characterInfo));
        InGameManager.instance.stockSystem.AddStockId(characterInfo);
        InGameManager.instance.combinationSystem.SubCharacter(characterInfo);
        DeleteCharacter();

        return deletedCharacterInfo;
    }

    public void DeleteCharacter()
    {
        character.DestoryPawn();
        character = null;
        characterInfo = null;

        OnCanNotClick();
    }

    public void UpgradeStar()
    {
        characterInfo.IncreaseStar();
        InGameManager.instance.combinationSystem.AddCharacter(characterInfo);
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
        gameObject.SetActive(false);
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
        var hitParticle = GameManager.instance.particleService.hitParticle;
        var frontCanvas = InGameManager.instance.frontCanvas;
        var particlePosition = new Vector3(transform.position.x, transform.position.y, InGameService.Z_VALUE_OF_PARTICLE);

        Instantiate(hitParticle, particlePosition, transform.rotation, frontCanvas.transform);
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

                var positionToMove = Vector2.Lerp(character.transform.position, this.transform.position, 0.05f);
                character.transform.position = new Vector3(positionToMove.x, positionToMove.y, InGameService.Z_VALUE_OF_PAWN);

                if (Mathf.Abs((character.transform.position - this.transform.position).y) < 0.01 )
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
            //character.transform.position = this.transform.position;
            character.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, InGameService.Z_VALUE_OF_PAWN);
        }
    }
}
