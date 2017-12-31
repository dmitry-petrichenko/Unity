using System;
using UnityEngine;
using Zenject;
using ZScripts.GameLoop;
using ZScripts.Map;
using ZScripts.Settings;

namespace ZScripts
{
    public class GameInstaller : MonoInstaller<GameInstaller>
    {
        [Inject]
        MapGraphicsList _mapGraphicsList = null;
        
        public event Action Updated;
        
        public override void InstallBindings()
        {
            MainScene.instance = gameObject;
            Container.BindInstance(this);
            Container.Bind<ISettings>().To<SettingsList>().AsSingle();
            Container.Bind<InputController>().To<InputController>().AsSingle().NonLazy();
            Container.Bind<ActiveMapLocationController>().To<ActiveMapLocationController>().AsSingle().NonLazy();
            Container.Bind<IGameLoopController>().To<GameLoopController>().AsSingle();
            Container.Bind<ICameraController>().To<CameraController>().AsSingle();
            MapInstaller.Install(Container);
            UnitsInstaller.Install(Container);
        }
        
        void Update()
        {
            if (Updated != null)
                Updated();
        }
        
        [Serializable]
        public class MapGraphicsList
        {
            public GameObject Plane, Cube, Square, Empty, Player;
        }
    }
}