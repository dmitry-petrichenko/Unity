using NSCameraController;
using NSGraphics;

namespace Labyrinth
{
    public class InputController
    {
        private IMapViewController _mapViewController;
        private IGraphicsController _graphicsController;
        private ICameraController _cameraController;
        
        public void Initialize()
        {
            _mapViewController = ServiceLocator.GetMapViewController();
            _graphicsController = ServiceLocator.GetGraphicsController();
            _cameraController = ServiceLocator.GetCameraController();
            
            _graphicsController.TileClicked += TileClickedHandler;
        }

        private void TileClickedHandler(IntVector2 position)
        {
            _mapViewController.UpdateCurrentPosition(position);
            _cameraController.UpdateCurrentPosition(position);
        }
    }
}