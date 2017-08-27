using Interfaces;
using Labyrinth.GameLoop;
using Labyrinth.Map;
using NSCameraController;
using Units;

namespace Labyrinth
{
    public static class ServiceLocator
    {
        private static IMapInfoController _mapInfoController;
        private static IMapViewController _mapViewController;
        private static IGraphicsController _graphicsController;
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

        public static void InitializeGraphicsController(IGraphicsController controller)
        {
            _graphicsController = controller;
        }

        public static IGraphicsController GetGraphicsController()
        {
            return _graphicsController;
        }

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