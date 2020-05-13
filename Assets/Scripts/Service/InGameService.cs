using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameService : MonoBehaviour
{
    public const int RATE_AT_WHICH_AFTERIMAGES_DISAPPEAR = 200;
    public const float SIZE_TO_EXPAND_THE_BATTLE_AREA = -200.0f;
    public const float SIZE_TO_SHRINK_THE_BATTLE_AREA = 0.0f;
    public const float SIZE_TO_BLUR = 0.5f;
    public const int NUMBER_OF_BACKAREA = 4;
    public const int NUMBER_OF_FRONTAREA = 3;


    public static Character character = GameObject.Find("DefaultCharacter").GetComponent<Character>();
    public static Enemy enemy = GameObject.Find("DefaultEnemy").GetComponent<Enemy>();
}
