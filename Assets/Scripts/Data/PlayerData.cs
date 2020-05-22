using System;
using System.Security.Permissions;

[Serializable]
public class PlayerData
{
    public int Level { get; set; }
    public int Gold { get; set; }
    public int Diamond { get; set; }
    public int PlayableStage { get; set; }
}