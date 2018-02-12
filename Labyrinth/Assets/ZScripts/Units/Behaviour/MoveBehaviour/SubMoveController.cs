using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ZScripts.Units
{
    public class SubMoveController : EventDispatcher, ISubMoveController
    {
        private IOneUnitServicesContainer _oneUnitServicesContainer;
        private List<IntVector2> _path;
        private IUnitsTable _unitsTable;
        private IntVector2 _nextOccupiedPossition;

        public IntVector2 Destination { get; set; }

        public SubMoveController(IUnitsTable unitsTable)
        {
            _unitsTable = unitsTable;
        }
        
        public void Initialize(IOneUnitServicesContainer oneUnitServicesContainer)
        {
            _oneUnitServicesContainer = oneUnitServicesContainer;
            _oneUnitServicesContainer.MotionController.StartMove += StartMoveHandler;
        }

        private void StartMoveHandler()
        {
            DispatchEvent(StartMove);
        }

        public void MoveTo(List<IntVector2> path)
        {
            if (path.Count == 0)
            {
                if (NoWayToPointHandler != null)
                {
                    NoWayToPointHandler(_nextOccupiedPossition);
                }
                return;
            }
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
                _oneUnitServicesContainer.RotationController.Rotate(_oneUnitServicesContainer.MotionController.Position, nextPosition);
                _oneUnitServicesContainer.AnimationController.PlayWalkAnimation();
                _oneUnitServicesContainer.MotionController.MoveToPosition(nextPosition);
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
            if (!_unitsTable.IsVacantPosition(nextPosition))
            {
                if (NextPositionOccupiedHandler != null)
                {
                    _nextOccupiedPossition = nextPosition;
                    NextPositionOccupiedHandler(nextPosition);
                }

                return true;
            }

            return false;
        }

        private void UpdateOccupationMap(IntVector2 newPosition, IntVector2 previousPosition)
        {
            _unitsTable.SetOccupied(newPosition);
            _unitsTable.SetVacant(previousPosition);
        }
        
        public void SetOnPosition(IntVector2 position)
        {
            _oneUnitServicesContainer.MotionController.SetOnPosition(position);
            _unitsTable.SetOccupied(Position);
        }

        public event Action MoveToComplete;
        public event Action MoveStepComplete;
        public event Action<IntVector2> NextPositionOccupiedHandler;
        public event Action<IntVector2> NoWayToPointHandler;
        public event Action StartMove;
    }
}