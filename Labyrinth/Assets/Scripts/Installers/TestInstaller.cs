using System;
using Zenject;
using UnityEngine;
using System.Collections;

public class TestInstaller : MonoInstaller
{
    [Inject]
    GameSettings _settings = null;
    
    public override void InstallBindings()
    {
        Debug.Log(_settings.Plane);
        Container.Bind<TestInstaller>().FromInstance(this);
    }
    
    [Serializable]
    public class GameSettings
    {
        public GameObject Plane, Cube, Square, Empty;
    }
}

