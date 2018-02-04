using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ZScripts.Units
{
    public class SubMoveController : ISubMoveController
    {
        private IOneUnitServicesContainer _oneUnitServicesContainer;
        private List<IntVector2> _path;
        private IOccupatedPossitionsTable _occupatedPossitionsTable;

        public IntVector2 Destination { get; set; }

        public SubMoveController(IOccupatedPossitionsTable occupatedPossitionsTable)
        {
            _occupatedPossitionsTable = occupatedPossitionsTable;
        }
        
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
                nextPosition = GetNextPossition();
                if (IsPositionOccupated(nextPosition)) return;
                UpdateOccupationMap(nextPosition, _oneUnitServicesContainer.MotionController.Position);
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

        private IntVector2 GetNextPossition()
        {
            IntVector2 nextPosition = _path[0];
            _path.RemoveAt(0);

            return nextPosition;
        }

        private bool IsPositionOccupated(IntVector2 nextPosition)
        {
            if (!_occupatedPossitionsTable.IsVacant(nextPosition))
            {
                if (NextPositionOccupiedHandler != null)
                {
                    NextPositionOccupiedHandler();
                }

                return true;
            }

            return false;
        }

        private void UpdateOccupationMap(IntVector2 newPosition, IntVector2 previousPosition)
        {
            _occupatedPossitionsTable.SetOccupied(newPosition);
            _occupatedPossitionsTable.SetVacant(previousPosition);
        }

        public event Action MoveToComplete;
        public event Action NextPositionOccupiedHandler;
        public event Action MoveStepComplete;
    }
}