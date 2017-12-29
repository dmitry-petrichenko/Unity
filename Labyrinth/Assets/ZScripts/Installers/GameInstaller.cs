using System;
using UnityEngine;
using Zenject;
using ZScripts.Settings;

namespace ZScripts
{
    public class GameInstaller : MonoInstaller<GameInstaller>
    {
        [Inject]
        MapGraphicsList _mapGraphicsList = null;
        
        public override void InstallBindings()
        {
            Container.Bind<ISettings>().To<SettingsList>().AsSingle();
        }
        
        [Serializable]
        public class MapGraphicsList
        {
            public GameObject Plane, Cube, Square, Empty;
        }
    }
}