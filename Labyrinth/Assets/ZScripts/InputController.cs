using ZScripts.Map;
using ZScripts.Map.View;
using ZScripts.Settings;
using ZScripts.Units;

namespace ZScripts
{
    public class InputController
    {
        private IMapController _mapController;
        private IMapViewController _mapViewController;
        private ICameraController _cameraController;
        private IUnitsController _unitsController;
        private ISettings _setings;

        public InputController(
            IMapController mapController,
            ISettings setings,
            IUnitsController  unitsController,
            ICameraController cameraController,
            IMapViewController mapViewController)
        {
            _mapController = mapController;
            _mapViewController = mapViewController;
            _unitsController = unitsController;
            _setings = setings;
            _cameraController = cameraController;

            Initialize();
        }

        public void Initialize()
        {
            _mapViewController.TileClicked += TileClickedHandler;

            _cameraController.Follow(_setings.PlayerGraphicsObject);

            _mapController.UpdateCurrentPosition(_unitsController.PlayerPosition);
        }

        private void TileClickedHandler(IntVector2 position)
        {
            //_cameraController.UpdateCurrentPosition(position);
            _unitsController.PlayerMoveTo(position);
        }
    }
}