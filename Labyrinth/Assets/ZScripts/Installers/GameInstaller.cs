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
            Container.Bind<ISettings>().To<SettingsList>().AsTransient();
            MapInstaller.Install(Container);
            UnitsInstaller.Install(Container);
        }
        
        [Serializable]
        public class MapGraphicsList
        {
            public GameObject Plane, Cube, Square, Empty, Player;
        }
    }
}