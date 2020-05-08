using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class InGameSaveData
{
    public List<CharacterInfo> characterAreaInfoList { get; set; }
    public List<CharacterInfo> prepareAreaInfoList { get; set; }
    public int Coin { get; set; }
    public int Stage { get; set; }
    public int Wave { get; set; }

    //public void SetInGameData(List<Character> characters, List<Enemy> enemies)
    //{
    //    this.Characters = characters;
    //    this.Enemies = enemies;
    //}
}
