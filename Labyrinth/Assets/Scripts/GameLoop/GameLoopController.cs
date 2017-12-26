﻿using System;
using UnityEngine;

namespace Labyrinth.GameLoop
{
    public class GameLoopController : IGameLoopController
    {
        public event Action Updated;

        private GameInstaller _gameController;


        public void Initialize(GameInstaller gameController)
        {
            _gameController = gameController;
            _gameController.Updated += UpdateHandler;
        }

        private void UpdateHandler()
        {
            if (Updated != null)
                Updated();
        }
    }
}