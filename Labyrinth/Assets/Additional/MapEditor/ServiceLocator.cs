using ZScripts.GameLoop;
using ZScripts.Map;
using ZScripts.Map.Info;
using ZScripts.Settings;
using ZScripts.Units;

namespace Additional
{
    public static class ServiceLocator
    {
        private static IMapInfoController _mapInfoController;
        private static IMapController _mapController;
        private static ICameraController _cameraController;
        private static IUnitsController _unitsController;
        private static ISettings _settings;
        private static IGameLoopController _gameLoopController;

        public static void InitializeGameLoopController(IGameLoopController gameLoopController)
        {
            _gameLoopController = gameLoopController;
        }

        public static IGameLoopController GetGameLoopController()
        {
            return _gameLoopController;
        }

        public static void InitializeUnitsController(IUnitsController unitsController)
        {
            _unitsController = unitsController;
        }

        public static IUnitsController GetUnitsController()
        {
            return _unitsController;
        }

        public static void InitializeSettings(ISettings settings)
        {
            _settings = settings;
        }

        public static ISettings GetSettings()
        {
            return _settings;
        }

        public static void InitializeCameraController(ICameraController controller)
        {
            _cameraController = controller;
        }

        public static ICameraController GetCameraController()
        {
            return _cameraController;
        }


        public static void InitializeMapViewController(IMapController controller)
        {
            _mapController = controller;
        }

        public static IMapController GetMapController()
        {
            return _mapController;
        }
    }
}