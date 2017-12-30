using System;
using UnityEngine;
using Zenject;
using ZScripts.Map;
using ZScripts.Settings;

namespace ZScripts
{
    public class GameInstaller : MonoInstaller<GameInstaller>
    {
        [Inject]
        MapGraphicsList _mapGraphicsList = null;
        
        public override void InstallBindings()
        {
            MainScene.instance = gameObject;
            Container.Bind<MainScene>().To<MainScene>().AsSingle();
            Container.Bind<ISettings>().To<SettingsList>().AsSingle();
            MapInstaller.Install(Container);
            
        }
        
        [Serializable]
        public class MapGraphicsList
        {
            public GameObject Plane, Cube, Square, Empty;
        }
    }
}