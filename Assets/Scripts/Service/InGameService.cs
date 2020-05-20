using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameService : MonoBehaviour
{
    public const int RATE_AT_WHICH_AFTERIMAGES_DISAPPEAR = 200;
    public const float SIZE_TO_EXPAND_THE_BATTLE_AREA = 100.0f;
    public const float SIZE_TO_BLUR = 0.5f;
    public const int NUMBER_OF_BACKAREA = 4;
    public const int NUMBER_OF_FRONTAREA = 3;
    public const int MAX_NUMBER_OF_CAN_PLACED = 7;
    public const int MIN_NUMBER_OF_CAN_PLACED = 0;
    public const int CAN_BUY_EXP = 1;

    public static Character defaultCharacter;
    public static Enemy defaultEnemy;

    public static void Initialize()
    {
        defaultCharacter = GameObject.Find("DefaultCharacter").GetComponent<Character>();
        defaultEnemy = GameObject.Find("DefaultEnemy").GetComponent<Enemy>();
    }
}
