﻿using System.Collections.Generic;
using Labyrinth;
using UnityEngine;

namespace NSGraphics
{
    public class GraphicsController : IGraphicsController
    {
        private GameObject _mainScene, _plane, _cube, _empty, _square;
        private Dictionary<IntVector2, GameObject> _activeGameObjects;
        private MouseClickListener _mouseClickListener;

        public void Initialize(GameObject mainScene, GameObject plane, GameObject cube, GameObject square,
            GameObject empty)
        {
            _mainScene = mainScene;
            _plane = plane;
            _cube = cube;
            _empty = empty;
            _square = square;
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

        public void InitializePlane(IntVector2 position)
        {
            var gameObject = Object.Instantiate(_plane, new Vector3(position.x, 0, position.y), Quaternion.identity,
                _mainScene.transform);
            AddActiveGameObject(position, gameObject);
        }

        public void InitializeSquare(IntVector2 position)
        {
            var gameObject = Object.Instantiate(_square, new Vector3(position.x, 0, position.y), Quaternion.identity,
                _mainScene.transform);
            AddActiveGameObject(position, gameObject);
        }

        public void InitializeCube(IntVector2 position)
        {
            var gameObject = Object.Instantiate(_cube, new Vector3(position.x, 0, position.y), Quaternion.identity,
                _mainScene.transform);
            AddActiveGameObject(position, gameObject);
        }

        public void InitializeEmpty(IntVector2 position)
        {
            var gameObject = Object.Instantiate(_empty, new Vector3(position.x, 0, position.y), Quaternion.identity,
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