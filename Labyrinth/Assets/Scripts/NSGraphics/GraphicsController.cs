using System.Collections.Generic;
using Labyrinth;
using UnityEngine;

namespace NSGraphics
{
    public class GraphicsController : IGraphicsController
    {
        private GameObject _plane, _cube, _empty, _square;
        private GameObject _mainScene;
        private Dictionary<IntVector2, GameObject> _activeGameObjects;
        
        public void Initialize(GameObject mainScene, GameObject plane, GameObject cube, GameObject square, GameObject empty)
        {
            _mainScene = mainScene;
            _plane = plane;
            _cube = cube;
            _empty = empty;
            _square = square;
            _activeGameObjects = new Dictionary<IntVector2, GameObject>();
        }

        public void InitializePlane(IntVector2 position)
        {
            var gameObject = Object.Instantiate(_plane, new Vector3(position.x, 0, position.y), Quaternion.identity, _mainScene.transform);
            _activeGameObjects.Add(position, gameObject);
        }
        
        public void InitializeSquare(IntVector2 position)
        {
            var gameObject = Object.Instantiate(_square, new Vector3(position.x, 0, position.y), Quaternion.identity, _mainScene.transform);
            _activeGameObjects.Add(position, gameObject);
        }

        public void InitializeCube(IntVector2 position)
        {
            var gameObject = Object.Instantiate(_cube, new Vector3(position.x, 0, position.y), Quaternion.identity, _mainScene.transform);
            _activeGameObjects.Add(position, gameObject);
        }

        public void InitializeEmpty(IntVector2 position)
        {
            var gameObject = Object.Instantiate(_empty, new Vector3(position.x, 0, position.y), Quaternion.identity, _mainScene.transform);
            _activeGameObjects.Add(position, gameObject);
        }

        public void DestroyTile(IntVector2 position)
        {
            if (!_activeGameObjects.ContainsKey(position))
                return;
            
            var gameObject = _activeGameObjects[position];
            Object.Destroy(gameObject);
            _activeGameObjects.Remove(position);
        }
    }
}