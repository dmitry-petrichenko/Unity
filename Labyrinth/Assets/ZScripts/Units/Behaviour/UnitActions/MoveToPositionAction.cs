using System;
using UnityEngine;

namespace ZScripts.Units.UnitActions
{
    public class MoveToPositionAction : IUnitAction
    {
        private IOneUnitController _oneUnitController;
        private IntVector2 startPoint = new IntVector2(0, 0);
        private IntVector2 endPoint = new IntVector2(7, 7);
        
        public MoveToPositionAction()
        {
            
        }

        private IntVector2 GenerateRandomPoint()
        {
            int x = UnityEngine.Random.Range(startPoint.x, endPoint.x);
            int y = UnityEngine.Random.Range(startPoint.y, endPoint.y);
            
            return new IntVector2(x, y);
        }
        
        public void Initialize(IOneUnitController oneUnitController)
        {
            _oneUnitController = oneUnitController;
        }
        
        public void Start()
        {
            _oneUnitController.CompleteMoveTo += MoveCompleteHandler;
            IntVector2 position = GenerateRandomPoint();
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

        public event Action OnComplete;
    }
}

