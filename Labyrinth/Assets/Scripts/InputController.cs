using NSCameraController;
using NSGraphics;
using Units;

namespace Labyrinth
{
    public class InputController
    {
        private IMapViewController _mapViewController;
        private IGraphicsController _graphicsController;
        private ICameraController _cameraController;
        private IUnitsController _unitsController;

        public void Initialize()
        {
            _mapViewController = ServiceLocator.GetMapViewController();
            _graphicsController = ServiceLocator.GetGraphicsController();
            _cameraController = ServiceLocator.GetCameraController();
            _unitsController = ServiceLocator.GetUnitsController();

            _graphicsController.TileClicked += TileClickedHandler;
        }

        private void TileClickedHandler(IntVector2 position)
        {
            _mapViewController.UpdateCurrentPosition(position);
            _cameraController.UpdateCurrentPosition(position);
            _unitsController.PlayerMoveTo(position);
        }
    }
}