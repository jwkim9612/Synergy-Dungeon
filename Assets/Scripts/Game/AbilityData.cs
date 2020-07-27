using System.Collections.Generic;

public class AbilityData
{
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

    public static AbilityData operator +(AbilityData ability1, AbilityData ability2)
    {
        AbilityData abilityData = new AbilityData();
        abilityData.Attack = ability1.Attack + ability2.Attack;
        abilityData.MagicalAttack = ability1.MagicalAttack + ability2.MagicalAttack;
        abilityData.Health = ability1.Health + ability2.Health;
        abilityData.Defence = ability1.Defence + ability2.Defence;
        abilityData.MagicDefence = ability1.MagicDefence + ability2.MagicDefence;
        abilityData.Shield = ability1.Shield + ability2.Shield;
        abilityData.Accuracy = ability1.Accuracy + ability2.Accuracy;
        abilityData.Evasion = ability1.Evasion + ability2.Evasion;
        abilityData.Critical = ability1.Critical + ability2.Critical;
        abilityData.AttackSpeed = ability1.AttackSpeed + ability2.AttackSpeed;

        return abilityData;
    }

    public List<long> GetAbilityDataList()
    {
        List<long> abilityDataList = new List<long>();

        abilityDataList.Add(Attack);
        abilityDataList.Add(MagicalAttack);
        abilityDataList.Add(Health);
        abilityDataList.Add(Defence);
        abilityDataList.Add(MagicDefence);
        abilityDataList.Add(Shield);
        abilityDataList.Add(Accuracy);
        abilityDataList.Add(Evasion);
        abilityDataList.Add(Critical);
        abilityDataList.Add(AttackSpeed);

        return abilityDataList;
    }

    public void SetAbilityData(CharacterAbilityData characterAbilityData)
    {
        Attack = characterAbilityData.Attack;
        MagicalAttack = characterAbilityData.MagicalAttack;
        Health = characterAbilityData.Health;
        Defence = characterAbilityData.Defence;
        MagicDefence = characterAbilityData.MagicDefence;
        Shield = characterAbilityData.Shield;
        Accuracy = characterAbilityData.Accuracy;
        Evasion = characterAbilityData.Evasion;
        Critical = characterAbilityData.Critical;
        AttackSpeed = characterAbilityData.AttackSpeed;
    }

    public void SetAbilityData(EnemyData enemyData)
    {
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
    }

    public void SetAbilityData(RuneExcelData runeExcelData)
    {
        Attack = runeExcelData.Attack;
        MagicalAttack = runeExcelData.MagicalAttack;
        Health = runeExcelData.Health;
        Defence = runeExcelData.Defence;
        MagicDefence = runeExcelData.MagicDefence;
        Shield = runeExcelData.Shield;
        Accuracy = runeExcelData.Accuracy;
        Evasion = runeExcelData.Evasion;
        Critical = runeExcelData.Critical;
        AttackSpeed = runeExcelData.AttackSpeed;
    }

       public void SetAbilityData(ArtifactCombinationExcelData artifactCombinationExcelData)
    {
        Attack = artifactCombinationExcelData.Attack;
        MagicalAttack = artifactCombinationExcelData.MagicalAttack;
        Health = artifactCombinationExcelData.Health;
        Defence = artifactCombinationExcelData.Defence;
        MagicDefence = artifactCombinationExcelData.MagicDefence;
        Shield = artifactCombinationExcelData.Shield;
        Accuracy = artifactCombinationExcelData.Accuracy;
        Evasion = artifactCombinationExcelData.Evasion;
        Critical = artifactCombinationExcelData.Critical;
        AttackSpeed = artifactCombinationExcelData.AttackSpeed;
    }
}
