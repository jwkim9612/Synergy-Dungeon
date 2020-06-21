using System;

[Serializable]
public class ScenarioExcelData
{
    public int ChapterId;
    public int StageId;
    public int WaveId;
    public int ScenarioId;
    public string ScenarioType;
    public int ScenarioProbability;
    public string Description;
    public InGameCurrency CurrencyType;
    public int Amount;
    public string RewardDescription;
}
