using System;
using System.Collections;
using UnityEngine;

namespace ZScripts.GameLoop
{
    public class GameLoopController : IGameLoopController
    {
        public event Action Updated;

        private GameInstaller _gameController;
        private Action _action;

        public GameLoopController(GameInstaller gameController)
        {
            _gameController = gameController;
            _gameController.Updated += UpdateHandler;
        }

        public void DelayStart(Action action, float time)
        {
            _action = action;

            _gameController.StartCoroutine(WaitAndDoAction(action, time));
        }
        
        IEnumerator WaitAndDoAction(Action action, float waitTime) {
            yield return new WaitForSeconds(waitTime);
            action.Invoke();
        }

        private void UpdateHandler()
        {
            if (Updated != null)
                Updated();
        }
    }
}