using Zenject;
using ZScripts.Map.Controllers;
using ZScripts.Map.Info;
using ZScripts.Map.View;

namespace ZScripts.Map
{
    public class MapInstaller : Installer<MapInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IMapController>().To<MapController>().AsSingle().NonLazy();
            Container.Bind<MapViewUpdateController>().To<MapViewUpdateController>().AsSingle();
            Container.Bind<MapInfoUpdateController>().To<MapInfoUpdateController>().AsSingle();
            Container.Bind<IMapViewController>().To<MapViewController>().AsSingle();
            Container.Bind<IMapInfoController>().To<MapInfoController>().AsSingle();
            //Container.Bind<IMapInfoStoreController>().To<MapInfoStoreController>().AsSingle();
        }
    }
}