using System.Collections.Generic;

public class AbilityData
{
    public int Attack;
    public int MagicalAttack;
    public int Health;
    public int Defence;
    public int MagicDefence;
    public int Shield;
    public int Accuracy;
    public int Evasion;
    public int Critical;
    public int AttackSpeed;

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

    public void SetAbilityData(CharacterAbilityExcelData characterAbilityExcelData)
    {
        Attack = characterAbilityExcelData.Attack;
        MagicalAttack = characterAbilityExcelData.MagicalAttack;
        Health = characterAbilityExcelData.Health;
        Defence = characterAbilityExcelData.Defence;
        MagicDefence = characterAbilityExcelData.MagicDefence;
        Shield = characterAbilityExcelData.Shield;
        Accuracy = characterAbilityExcelData.Accuracy;
        Evasion = characterAbilityExcelData.Evasion;
        Critical = characterAbilityExcelData.Critical;
        AttackSpeed = characterAbilityExcelData.AttackSpeed;
    }

    public void SetAbilityData(CharacterAbilityData characterAbilityData)
    {
        Attack = characterAbilityData.abilityData.Attack;
        MagicalAttack = characterAbilityData.abilityData.MagicalAttack;
        Health = characterAbilityData.abilityData.Health;
        Defence = characterAbilityData.abilityData.Defence;
        MagicDefence = characterAbilityData.abilityData.MagicDefence;
        Shield = characterAbilityData.abilityData.Shield;
        Accuracy = characterAbilityData.abilityData.Accuracy;
        Evasion = characterAbilityData.abilityData.Evasion;
        Critical = characterAbilityData.abilityData.Critical;
        AttackSpeed = characterAbilityData.abilityData.AttackSpeed;
    }

    public void SetAbilityData(EnemyExcelData enemyExcelData)
    {
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
    }

    public void SetAbilityData(AbilityData abilityData)
    {
        Attack = abilityData.Attack;
        MagicalAttack = abilityData.MagicalAttack;
        Health = abilityData.Health;
        Defence = abilityData.Defence;
        MagicDefence = abilityData.MagicDefence;
        Shield = abilityData.Shield;
        Accuracy = abilityData.Accuracy;
        Evasion = abilityData.Evasion;
        Critical = abilityData.Critical;
        AttackSpeed = abilityData.AttackSpeed;
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

    public void SetAbilityData(ArtifactExcelData artifactExcelData)
    {
        Attack = artifactExcelData.Attack;
        MagicalAttack = artifactExcelData.MagicalAttack;
        Health = artifactExcelData.Health;
        Defence = artifactExcelData.Defence;
        MagicDefence = artifactExcelData.MagicDefence;
        Shield = artifactExcelData.Shield;
        Accuracy = artifactExcelData.Accuracy;
        Evasion = artifactExcelData.Evasion;
        Critical = artifactExcelData.Critical;
        AttackSpeed = artifactExcelData.AttackSpeed;
    }

    public void AllAbilityUpByPercentage(int percentage)
    {
        Attack = (int)(Attack * (1 + (percentage * 0.01f)));
        MagicalAttack = (int)(MagicalAttack * (1 + (percentage * 0.01f)));
        Health = (int)(Health * (1 + (percentage * 0.01f)));
        Defence = (int)(Defence * (1 + (percentage * 0.01f)));
        MagicDefence = (int)(MagicDefence * (1 + (percentage * 0.01f)));
        Shield = (int)(Shield * (1 + (percentage * 0.01f)));
        Accuracy = (int)(Accuracy * (1 + (percentage * 0.01f)));
        Evasion = (int)(Evasion * (1 + (percentage * 0.01f)));
        Critical = (int)(Critical * (1 + (percentage * 0.01f)));
        AttackSpeed = (int)(AttackSpeed * (1 + (percentage * 0.01f)));
    }
}
