using Labyrinth;
using Labyrinth.GameLoop;
using UnityEngine;

namespace NSCameraController
{
    public class CameraController : ICameraController
    {
        private Camera _camera;
        private int _yPosition;
        private GameObject _gameObject;
        private IGameLoopController _gameLoopController;
        private Vector3 _offset;

        public void Initialize(Camera camera, int yPosition = 15)
        {
            _camera = camera;
            _yPosition = yPosition;
            _gameLoopController = ServiceLocator.GetGameLoopController();
        }

        public void UpdateCurrentPosition(IntVector2 position)
        {
            _camera.transform.position = new Vector3(position.x, _yPosition, position.y);
        }

        public void Follow<T>(T gameObject)
        {
             _gameLoopController.Updated += UpdateHandler;
             _gameObject = gameObject as GameObject;
             _offset = _camera.transform.position - _gameObject.transform.position;
        }
 
        private void UpdateHandler()
        {
            _camera.transform.position = _gameObject.transform.position + _offset;
        }
    }
}