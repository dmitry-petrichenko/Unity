using UnityEngine;

namespace NSGraphics
{
    public class GraphicsController : IGraphicsController
    {
        private GameObject _plane, _cube, _empty;
        private GameObject _mainScene;
        
        public void Initialize(GameObject mainScene, GameObject plane, GameObject cube, GameObject empty)
        {
            _mainScene = mainScene;
            _plane = plane;
            _cube = cube;
            _empty = empty;
        }

        public void InitializePlane(IntVector2 position)
        {
            Object.Instantiate(_plane, new Vector3(position.x, 0, position.y), Quaternion.identity, _mainScene.transform);
        }

        public void InitializeCube(IntVector2 position)
        {
            Object.Instantiate(_cube, new Vector3(position.x, 0, position.y), Quaternion.identity, _mainScene.transform);
        }

        public void InitializeEmpty(IntVector2 position)
        {
            Object.Instantiate(_empty, new Vector3(position.x, 0, position.y), Quaternion.identity, _mainScene.transform);
        }
    }
}