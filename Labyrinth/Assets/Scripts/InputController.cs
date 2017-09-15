using Labyrinth.Map;
using NSCameraController;
using Units;

namespace Labyrinth
{
    public class InputController
    {
        private IMapController _mapController;
        private IMapViewController _mapViewController;
        private ICameraController _cameraController;
        private IUnitsController _unitsController;
        private ISettings _setingsController;

        public void Initialize()
        {
            _mapController = ServiceLocator.GetMapController();
            _mapViewController = MapServiceLocator.GetMapViewController();
            _cameraController = ServiceLocator.GetCameraController();
            _unitsController = ServiceLocator.GetUnitsController();
            _setingsController = ServiceLocator.GetSettings();

            _mapViewController.TileClicked += TileClickedHandler;

            _cameraController.Follow(_setingsController.PlayerGraphicsObject);

            _mapController.UpdateCurrentPosition(_unitsController.Player.Position);
        }

        private void TileClickedHandler(IntVector2 position)
        {
            _mapController.UpdateCurrentPosition(position);
            //_cameraController.UpdateCurrentPosition(position);
            _unitsController.PlayerMoveTo(position);
        }
    }
}