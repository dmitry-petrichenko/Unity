using System;
using System.Collections.Generic;
using UnityEngine;
using ZScripts.Units.PathFinder;

namespace ZScripts.Units.UnitActions
{
    public class MoveToPositionAction : IUnitAction
    {
        private IOneUnitController _oneUnitController;
        private IMovingRandomizer _movingRandomizer;
        
        public MoveToPositionAction(IMovingRandomizer movingRandomizer)
        {
            _movingRandomizer = movingRandomizer;
        }

        public void Start()
        {
            _oneUnitController.CompleteMoveTo += MoveCompleteHandler;
            IntVector2 position = _movingRandomizer.GetRandomPoint(_oneUnitController.Position);
            _oneUnitController.MoveTo(position);
        }

        private void MoveCompleteHandler()
        {
            if (OnComplete != null)
            {
                OnComplete();
            }
        }

        public void Stop()
        {
            
        }

        public void Destroy()
        {
            
        }

        public void Initialize(IOneUnitController oneUnitController)
        {
            _oneUnitController = oneUnitController;
        }

        public event Action OnComplete;
    }
}

