using System;
using ZScripts.GameLoop;

namespace ZScripts.Units.Behaviour.UnitActions
{
    public class AttackAction : IUnitAction
    {
        private float delayTime;
        private IGameLoopController _gameloopController;
        private IOneUnitController _oneUnitController;
        
        public AttackAction(IGameLoopController gameloopController)
        {
            _gameloopController = gameloopController;
            delayTime = 1.5f;
        }
        
        public void Start()
        {
            _oneUnitController.AnimationController.PlayAttackAnimation();
            _gameloopController.DelayStart(TriggerComplete, delayTime);
        }

        public void Stop()
        {
            
        }

        public void Destroy()
        {
            
        }

        public void Initialize(IOneUnitController oneUnitController)
        {
               
        }
        
        public void Initialize(IOneUnitController oneUnitController, IntVector2 position)
        {
            _oneUnitController = oneUnitController;
        }
        
        private void TriggerComplete()
        {
            if (OnComplete != null)
            {
                OnComplete();
            } 
        }

        public event Action OnComplete;
    }
}