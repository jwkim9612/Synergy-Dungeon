﻿using UnityEngine;

public class EnemyData
{
    public EnemyData(EnemyExcelData enemyExcelData)
    {
        Id = enemyExcelData.Id;
        Name = enemyExcelData.Name;
        Attack = enemyExcelData.Attack;
        MagicalAttack = enemyExcelData.MagicalAttack;
        Health = enemyExcelData.Health;
        Defence = enemyExcelData.Defence;
        MagicDefence = enemyExcelData.MagicDefence;
        Shield = enemyExcelData.Shield;
        Accuracy = enemyExcelData.Accuracy;
        Evasion = enemyExcelData.Evasion;
        Critical = enemyExcelData.Critical;
        AttackSpeed = enemyExcelData.AttackSpeed;

        Image = Resources.Load<Sprite>(enemyExcelData.ImagePath);
        RuntimeAnimatorController = Resources.Load<RuntimeAnimatorController>(enemyExcelData.RuntimeAnimatorControllerPath);
    }

    public EnemyData(EnemyData enemyData)
    {
        Id = enemyData.Id;
        Name = enemyData.Name;
        Attack = enemyData.Attack;
        MagicalAttack = enemyData.MagicalAttack;
        Health = enemyData.Health;
        Defence = enemyData.Defence;
        MagicDefence = enemyData.MagicDefence;
        Shield = enemyData.Shield;
        Accuracy = enemyData.Accuracy;
        Evasion = enemyData.Evasion;
        Critical = enemyData.Critical;
        AttackSpeed = enemyData.AttackSpeed;
        Image = enemyData.Image;
        RuntimeAnimatorController = enemyData.RuntimeAnimatorController;
    }

    public int Id;
    public string Name;
    public long Attack;
    public long MagicalAttack;
    public long Health;
    public long Defence;
    public long MagicDefence;
    public long Shield;
    public long Accuracy;
    public long Evasion;
    public long Critical;
    public long AttackSpeed;
    public Sprite Image;
    public RuntimeAnimatorController RuntimeAnimatorController;
}