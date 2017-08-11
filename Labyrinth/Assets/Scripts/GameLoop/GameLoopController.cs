using System;
using UnityEngine;

namespace Labyrinth.GameLoop
{
    public class GameLoopController : IGameLoopController
    {
        public event Action Updated;
        
        private GameController _gameController;
        
        
        public void Initialize(GameController gameController)
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