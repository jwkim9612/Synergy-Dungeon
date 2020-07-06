using UnityEngine;

public class CharacterInfo
{
    public CharacterInfo()
    {
    }

    public CharacterInfo(int id, int star)
    {
        this.id = id;
        this.star = star;
    }

    public CharacterInfo(int id)
    {
        this.id = id;
        this.star = CharacterService.DEFAULT_CHARACTER_STAR;
    }

    public override bool Equals(object obj)
    {
        CharacterInfo characterInfo = obj as CharacterInfo;
        return (characterInfo.id == id && characterInfo.star == star) ? true : false;
    }

    public override int GetHashCode()
    {
        return this.id.GetHashCode();
    }

    public void IncreaseStar()
    {
        if(star <= 0 || star > 2)
        {
            Debug.LogError($"Error IncreaseStar star:{star}");
            return;
        }

        ++star;
    }

    public int id;
    public int star;
}
