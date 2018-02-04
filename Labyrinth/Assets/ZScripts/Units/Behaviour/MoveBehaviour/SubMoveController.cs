using System;
using System.Collections.Generic;
using UnityEditor;

namespace ZScripts.Units
{
    public class SubMoveController : ISubMoveController
    {
        private IOneUnitServicesContainer _oneUnitServicesContainer;
        private List<IntVector2> _path;
        
        public void Initialize(IOneUnitServicesContainer oneUnitServicesContainer)
        {
            _oneUnitServicesContainer = oneUnitServicesContainer;
        }
        
        public void MoveTo(List<IntVector2> path)
        {
            _oneUnitServicesContainer.MotionController.CompleteMove += MoveStepCompleteHandler;
            _oneUnitServicesContainer.MotionController.CompleteMove += MoveNextStep;
            _path = path;
            MoveNextStep();
        }

        private void MoveStepCompleteHandler()
        {                            
            if (MoveStepComplete != null)
            {
                MoveStepComplete();
            }
        }

        public void Cancel()
        {
            _oneUnitServicesContainer.MotionController.CompleteMove -= MoveNextStep;
        }

        public IntVector2 Position
        {
            get { return _oneUnitServicesContainer.MotionController.Position; }
        }

        public bool IsMoving
        {
            get { return _oneUnitServicesContainer.MotionController.IsMoving; }
        }

        private void MoveNextStep()
        {
            IntVector2 nextPosition;
            
            if (_path.Count > 0)
            {
                nextPosition = _path[0];
                _path.RemoveAt(0);
                _oneUnitServicesContainer.MotionController.MoveToPosition(nextPosition);
                _oneUnitServicesContainer.AnimationController.PlayWalkAnimation();
                _oneUnitServicesContainer.RotationController.Rotate(_oneUnitServicesContainer.MotionController.Position, nextPosition);
            }
            else
            {
                _oneUnitServicesContainer.MotionController.CompleteMove -= MoveNextStep;
                
                if (MoveToComplete != null)
                {
                    MoveToComplete();
                }
            }
        }

        public event Action MoveToComplete;
        public event Action NextPositionOccupiedHandler;
        public event Action MoveStepComplete;
    }
}