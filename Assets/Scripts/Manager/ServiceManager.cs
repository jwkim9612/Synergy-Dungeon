using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceManager : MonoSingleton<ServiceManager>
{
    public void  Initialize()
    {
        RuneService.Initialize();
    }
}
