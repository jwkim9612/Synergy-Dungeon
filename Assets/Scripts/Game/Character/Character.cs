using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using geniikw.DataSheetLab;

public class Character : Pawn
{
    public Character()
    {
        pawnType = PawnType.Character;
    }

    public float GetSize()
    {
        return spriteRenderer.transform.localScale.x;
    }

    public void OnHide()
    {
        spriteRenderer.gameObject.SetActive(false);
    }

    public void OnShow()
    {
        spriteRenderer.gameObject.SetActive(true);

    }
}
