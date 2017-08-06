using Labyrinth;
using UnityEngine;

namespace NSCameraController
{
    public class CameraController : ICameraController
    {
        private Camera _camera;
        
        public void Initialize(Camera camera)
        {
            _camera = camera;
        }

        public void UpdateCurrentPosition(IntVector2 position)
        {
            _camera.transform.position = new Vector3(position.x, 15, position.y);
        }
    }
}