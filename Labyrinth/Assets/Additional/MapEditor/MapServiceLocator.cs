using Additional.Tests.SectorLoader;
using ZScripts.Map.Info;
using ZScripts.Map.View;
using MapViewController = Additional.Tests.SectorLoader.MapViewController;

namespace Additional
{
    public static class MapServiceLocator
    {
        private static IMapInfoController _mapInfoController;
        private static IMapViewController _mapViewController;
        private static GraphicsController _sectorGraphicsController;
        
        public static void InitializeMapInfoController(IMapInfoController controller)
        {
            _mapInfoController = controller;
        }

        public static IMapInfoController GetMapInfoController()
        {
            return _mapInfoController;
        }
        
        public static void InitializeMapViewController(IMapViewController controller)
        {
            _mapViewController = controller;
        }
        
        public static void InitializeSectorGraphicsController(GraphicsController controller)
        {
            _sectorGraphicsController = controller;
        }
        
        public static GraphicsController GetSectorGraphicsController()
        {
            return _sectorGraphicsController;
        }

        public static IMapViewController GetMapViewController()
        {
            return _mapViewController;
        }
    }
}