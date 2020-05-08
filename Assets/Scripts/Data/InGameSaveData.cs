using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class InGameSaveData
{
    public List<Character> Characters { get; set; }
    public List<Enemy> Enemies { get; set; }
    public int Coin { get; set; }

    public void SetInGameData(List<Character> characters, List<Enemy> enemies)
    {
        this.Characters = characters;
        this.Enemies = enemies;
    }
}
