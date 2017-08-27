using Interfaces;
using NSCameraController;
using Units;
using UnityEngine;

namespace Labyrinth
{
    public class InputController
    {
        private IMapViewController _mapViewController;
        private IGraphicsController _graphicsController;
        private ICameraController _cameraController;
        private IUnitsController _unitsController;
        private ISettings _setingsController;

        public void Initialize()
        {
            _mapViewController = ServiceLocator.GetMapViewController();
            _graphicsController = ServiceLocator.GetGraphicsController();
            _cameraController = ServiceLocator.GetCameraController();
            _unitsController = ServiceLocator.GetUnitsController();
            _setingsController = ServiceLocator.GetSettings();

            _graphicsController.TileClicked += TileClickedHandler;

            _cameraController.Follow(_setingsController.PlayerGraphicsObject);

            _mapViewController.UpdateCurrentPosition(_unitsController.Player.Position);
        }

        private void TileClickedHandler(IntVector2 position)
        {
            _mapViewController.UpdateCurrentPosition(position);
            //_cameraController.UpdateCurrentPosition(position);
            _unitsController.PlayerMoveTo(position);
        }
    }
}