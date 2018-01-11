using ZScripts.Map.Info;
using ZScripts.Map.View;

namespace Additional
{
    public static class MapServiceLocator
    {
        private static IMapInfoController _mapInfoController;
        private static IMapViewController _mapViewController;
        
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

        public static IMapViewController GetMapViewController()
        {
            return _mapViewController;
        }
    }
}