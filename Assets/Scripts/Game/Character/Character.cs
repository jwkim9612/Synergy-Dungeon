using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using geniikw.DataSheetLab;

public class Character : Pawn
{
    Action currentAction;

    public Character()
    {
        pawnType = PawnType.Character;
    }

    public void SetAction(Action action)
    {
        currentAction = action;
    }
}
