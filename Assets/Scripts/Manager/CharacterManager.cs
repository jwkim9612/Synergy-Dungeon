using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using geniikw.DataSheetLab;
using SharedService;

public class CharacterManager : MonoBehaviour
{
    public CharacterSheet characterDatas;

    //public List<CharacterData> normalStock = null;
    //public List<CharacterData> magicStock = null;
    //public List<CharacterData> rareStock = null;
    //public List<CharacterData> uniqueStock = null;
    //public List<CharacterData> legendStock = null;

    //public void InitializeStock()
    //{
    //    ClearAllStock();

    //    foreach(var characterData in characterDatas)
    //    {
    //        for (int i = 0; i < Card.MAX_NUM_OF_CARDS_PER_CHARACTER; ++i)
    //        {
    //            switch (characterData.tier)
    //            {
    //                case Tier.One:
    //                    normalStock.Add(characterData);
    //                    break;
    //                case Tier.Two:
    //                    magicStock.Add(characterData);
    //                    break;
    //                case Tier.Three:
    //                    rareStock.Add(characterData);
    //                    break;
    //                case Tier.Four:
    //                    uniqueStock.Add(characterData);
    //                    break;
    //                case Tier.Five:
    //                    legendStock.Add(characterData);
    //                    break;
    //                default:
    //                    Debug.Log("Erro InitializeStock");
    //                    break;
    //            }
    //        }
    //    }
    //}

    //public void ClearAllStock()
    //{
    //    normalStock.Clear();
    //    magicStock.Clear();
    //    rareStock.Clear();
    //    legendStock.Clear();
    //    uniqueStock.Clear();
    //}

    //public void RemoveStock(CharacterData characterData)
    //{
    //    switch (characterData.tier)
    //    {
    //        case Tier.One:
    //            normalStock.Remove(characterData);
    //            break;
    //        case Tier.Two:
    //            magicStock.Remove(characterData);
    //            break;
    //        case Tier.Three:
    //            rareStock.Remove(characterData);
    //            break;
    //        case Tier.Four:
    //            uniqueStock.Remove(characterData);
    //            break;
    //        case Tier.Five:
    //            legendStock.Remove(characterData);
    //            break;
    //        default:
    //            Debug.Log("Erro RemoveStock");
    //            break;
    //    }
    //}

    //public void ShuffleStock(Tier tier)
    //{
    //    switch (tier)
    //    {
    //        case Tier.One:
    //            SharedRandom.Shuffle<CharacterData>(normalStock);
    //            break;
    //        case Tier.Two:
    //            SharedRandom.Shuffle<CharacterData>(magicStock);
    //            break;
    //        case Tier.Three:
    //            SharedRandom.Shuffle<CharacterData>(rareStock);
    //            break;
    //        case Tier.Four:
    //            SharedRandom.Shuffle<CharacterData>(uniqueStock);
    //            break;
    //        case Tier.Five:
    //            SharedRandom.Shuffle<CharacterData>(legendStock);
    //            break;
    //        default:
    //            Debug.Log("Erro ShuffleStock");
    //            break;
    //    }
    //}
}
