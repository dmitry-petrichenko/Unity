using System.Collections.Generic;
using Labyrinth.Map;
using UnityEditor;
using UnityEngine;

namespace Labyrinth.Additional.Tests
{
    public class MapViewController 
    {
        private GameObject _mainScene, _empty, _busy, _start, _end, _way, _minor, _closelist, _open;
        private Dictionary<IntVector2, GameObject> _activeGameObjects;
        private MouseClickListener _mouseClickListener;

        public void Initialize(GameObject mainScene, 
            GameObject empty,
            GameObject busy,
            GameObject start,
            GameObject end,
            GameObject way,
            GameObject minor,
            GameObject closelist,
            GameObject open
            )
        {
            
            _mainScene = mainScene;
            _empty = empty;
            _busy = busy;
            _start = start;
            _end = end;
            _way = way;
            _minor = minor;
            _closelist = closelist;
            _open = open;
            
            _activeGameObjects = new Dictionary<IntVector2, GameObject>();

            _mouseClickListener = _mainScene.AddComponent<MouseClickListener>();
            _mouseClickListener.TileClicked += TileClickedHandler;
            _mouseClickListener.TileClicked += RightClickedHandler;
        }

        private void TileClickedHandler(IntVector2 position)
        {
            if (TileClicked != null)
                TileClicked(position);
        }

        private void RightClickedHandler(IntVector2 position)
        {
            if (RightClicked != null)
                RightClicked(position);
        }
        
        public void InitializeOpen(IntVector2 position)
        {
            DestroyTile(position);
            var gameObject = Object.Instantiate(_open, new Vector3(position.x, 0, position.y), Quaternion.identity,
                _mainScene.transform);
            AddActiveGameObject(position, gameObject);
        }

        public void InitializeStart(IntVector2 position)
        {
            DestroyTile(position);
            var gameObject = Object.Instantiate(_start, new Vector3(position.x, 0, position.y), Quaternion.identity,
                _mainScene.transform);
            AddActiveGameObject(position, gameObject);
        }

        public void InitializeEnd(IntVector2 position)
        {
            DestroyTile(position);
            var gameObject = Object.Instantiate(_end, new Vector3(position.x, 0, position.y), Quaternion.identity,
                _mainScene.transform);
            AddActiveGameObject(position, gameObject);
        }
        
        public void InitializeCloseList(IntVector2 position)
        {
            DestroyTile(position);
            var gameObject = Object.Instantiate(_closelist, new Vector3(position.x, 0, position.y), Quaternion.identity,
                _mainScene.transform);
            AddActiveGameObject(position, gameObject);
        }

        public void InitializeWay(IntVector2 position)
        {
            DestroyTile(position);
            var gameObject = Object.Instantiate(_way, new Vector3(position.x, 0, position.y), Quaternion.identity,
                _mainScene.transform);
            AddActiveGameObject(position, gameObject);
        }

        public void InitializeEmpty(IntVector2 position)
        {
            DestroyTile(position);
            var gameObject = Object.Instantiate(_empty, new Vector3(position.x, 0, position.y), Quaternion.identity,
                _mainScene.transform);
            AddActiveGameObject(position, gameObject);
        }
        
        public void InitializeBusy(IntVector2 position)
        {
            DestroyTile(position);
            var gameObject = Object.Instantiate(_busy, new Vector3(position.x, 0, position.y), Quaternion.identity,
                _mainScene.transform);
            AddActiveGameObject(position, gameObject);
        }
        
        public void InitializMinor(IntVector2 position)
        {
            DestroyTile(position);
            var gameObject = Object.Instantiate(_minor, new Vector3(position.x, 0, position.y), Quaternion.identity,
                _mainScene.transform);
            AddActiveGameObject(position, gameObject);
        }

        public void DestroyTile(IntVector2 position)
        {
            if (!_activeGameObjects.ContainsKey(position))
                return;

            var gameObject = _activeGameObjects[position];
            Object.Destroy(gameObject);
            _activeGameObjects.Remove(position);
        }

        public event TileClickHandler TileClicked;
        public event TileClickHandler RightClicked;

        private void AddActiveGameObject(IntVector2 position, GameObject gameObject)
        {
            _activeGameObjects.Add(position, gameObject);
        }
    }
}