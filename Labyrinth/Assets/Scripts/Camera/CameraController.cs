using Labyrinth;
using UnityEngine;

namespace NSCameraController
{
    public class CameraController : ICameraController
    {
        private Camera _camera;
        private int _yPosition;

        public void Initialize(Camera camera, int yPosition = 15)
        {
            _camera = camera;
            _yPosition = yPosition;
        }

        public void UpdateCurrentPosition(IntVector2 position)
        {
            _camera.transform.position = new Vector3(position.x, _yPosition, position.y);
        }
    }
}