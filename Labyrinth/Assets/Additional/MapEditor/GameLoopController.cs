using System;
using ZScripts.GameLoop;

namespace Additional
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