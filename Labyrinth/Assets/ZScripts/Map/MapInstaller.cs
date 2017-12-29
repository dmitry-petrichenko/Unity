using UnityEngine;
using Zenject;

namespace ZScripts.Map
{
    public class MapInstaller : Installer<MapInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IMapController>().To<MapController>().AsSingle().NonLazy();
        }
    }
}