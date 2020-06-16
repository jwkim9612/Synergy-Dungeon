using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynergySystem
{
    public delegate void OnTribeChangedDelegate();
    public OnTribeChangedDelegate OnTribeChanged { get; set; }

    public delegate void OnOriginChangedDelegate();
    public OnOriginChangedDelegate OnOriginChanged { get; set; }

    public Dictionary<TribeInfo, int> deployedTribes;
    public Dictionary<OriginInfo, int> deployedOrigins;
    public Dictionary<Tribe, int> appliedTribes;
    public Dictionary<Origin, int> appliedOrigins;

    public void Initialize()
    {
        deployedTribes = new Dictionary<TribeInfo, int>();
        deployedOrigins = new Dictionary<OriginInfo, int>();
        appliedTribes = new Dictionary<Tribe, int>();
        appliedOrigins = new Dictionary<Origin, int>();
    }

    public void AddCharacter(CharacterInfo characterInfo)
    {
        TribeInfo tribeInfo = new TribeInfo(GameManager.instance.dataSheet.characterDataSheet.characterDatas[characterInfo.id].Tribe, characterInfo.id);
        OriginInfo originInfo = new OriginInfo(GameManager.instance.dataSheet.characterDataSheet.characterDatas[characterInfo.id].Origin, characterInfo.id);

        if (deployedTribes.ContainsKey(tribeInfo))
        {
            ++deployedTribes[tribeInfo];
        }
        else
        {
            deployedTribes.Add(tribeInfo, 1);
            AddAppliedTribe(tribeInfo.tribe);
        }

        if (deployedOrigins.ContainsKey(originInfo))
        {
            ++deployedOrigins[originInfo];
        }
        else
        {
            deployedOrigins.Add(originInfo, 1);
            AddAppliedOrigin(originInfo.origin);
        }
    }

    public void SubCharacter(CharacterInfo characterInfo)
    {
        TribeInfo tribeInfo = new TribeInfo(GameManager.instance.dataSheet.characterDataSheet.characterDatas[characterInfo.id].Tribe, characterInfo.id);
        OriginInfo originInfo = new OriginInfo(GameManager.instance.dataSheet.characterDataSheet.characterDatas[characterInfo.id].Origin, characterInfo.id);

        if (deployedTribes.ContainsKey(tribeInfo))
        {
            --deployedTribes[tribeInfo];

            if(deployedTribes[tribeInfo] == 0)
            {
                deployedTribes.Remove(tribeInfo);
                SubAppliedTribe(tribeInfo.tribe);
            }
        }
        else
        {
            Debug.Log("Error No Tribes");
        }

        if (deployedOrigins.ContainsKey(originInfo))
        {
            --deployedOrigins[originInfo];

            if (deployedOrigins[originInfo] == 0)
            {
                deployedOrigins.Remove(originInfo);
                SubAppliedOrigin(originInfo.origin);
            }
        }
        else
        {
            Debug.Log("Error No Origins");
        }

    }

    public void AddAppliedTribe(Tribe tribe)
    {
        if (appliedTribes.ContainsKey(tribe))
        {
            ++appliedTribes[tribe];
        }
        else
        {
            appliedTribes.Add(tribe, 1);
        }

        OnTribeChanged();
    }

    public void AddAppliedOrigin(Origin origin)
    {
        if (appliedOrigins.ContainsKey(origin))
        {
            ++appliedOrigins[origin];
        }
        else
        {
            appliedOrigins.Add(origin, 1);
        }

        OnOriginChanged();
    }


    public void SubAppliedTribe(Tribe tribe)
    {
        if (appliedTribes.ContainsKey(tribe))
        {
            --appliedTribes[tribe];

            if (appliedTribes[tribe] == 0)
            {
                appliedTribes.Remove(tribe);
            }
        }
        else
        {
            Debug.Log("Error No AppliedTribes");
        }

        OnTribeChanged();
    }

    public void SubAppliedOrigin(Origin origin)
    {
        if (appliedOrigins.ContainsKey(origin))
        {
            --appliedOrigins[origin];

            if (appliedOrigins[origin] == 0)
            {
                appliedOrigins.Remove(origin);
            }
        }
        else
        {
            Debug.Log("Error No AppliedOrigins");
        }

        OnOriginChanged();
    }

    public void SubCharacterFromCombinations(UICharacter uiCharacter, bool isFirstCharacter)
    {
        if (isFirstCharacter)
            return;

        if (uiCharacter.GetArea<UIBattleArea>() != null)
            InGameManager.instance.synergySystem.SubCharacter(uiCharacter.characterInfo);
    }
}
