using UnityEngine;

public class BattleLogService : MonoBehaviour
{
    [SerializeField] private UIBattleLog uiBattleLog = null;

    public void AddBattleLog(string log)
    {
        uiBattleLog.AddBattleLog(log);
    }
}
