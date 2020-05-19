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
    public int coin { get; set; }
    public int chapter { get; set; }
    public int wave { get; set; }

    //public void SetInGameData(List<Character> characters, List<Enemy> enemies)
    //{
    //    this.Characters = characters;
    //    this.Enemies = enemies;
    //}
}
