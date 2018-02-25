using System.Collections.Generic;
using UnityEngine;
using ZScripts.Units.PathFinder;
using ZScripts.Units.Player;
using ZScripts.Units.StateInfo;

namespace ZScripts.Units
{
    public class WaitMoveTurnController
    {
        private IOneUnitController _oneUnitController;
        private readonly IUnitsTable _unitsTable;
        private IOneUnitController _targetUnit;
        private IPathFinderController _pathFinderController;
        private IntVector2 _occupiedPoint;
        private IMovingRandomizer _movingRandomizer;
        private IOneUnitMotionController _motionController;
        private IUnitStateInfo _unitStateInfo;
        
        public WaitMoveTurnController(
            IUnitsTable unitsTable,
            IPathFinderController pathFinderController,
            IMovingRandomizer movingRandomizer,
            IOneUnitMotionController oneUnitMotionController,
            IUnitStateInfo unitStateInfo
            )
        {
            _unitsTable = unitsTable;
            _pathFinderController = pathFinderController;
            _pathFinderController = pathFinderController;
            _movingRandomizer = movingRandomizer;
            _motionController = oneUnitMotionController;
            _unitStateInfo = unitStateInfo;
        }
        
        private ISubMoveController _subMoveController;
        
        public void Initialize(ISubMoveController subMoveController, IOneUnitController oneUnitController)
        {
            _oneUnitController = oneUnitController;
            _subMoveController = subMoveController;
            _subMoveController.NoWayToPointHandler += NoWayToPointHandler;
        }

        private void NoWayToPointHandler(IntVector2 occupiedPoint)
        {
            _occupiedPoint = occupiedPoint;
            WaitUnitOnPosition(_occupiedPoint);
        }

        private void WaitUnitOnPosition(IntVector2 position)
        {
            _targetUnit = _unitsTable.GetUnitOnPosition(position);
            if (_unitStateInfo.WaitPosition.x == _subMoveController.Position.x &&
                _unitStateInfo.WaitPosition.y == _subMoveController.Position.y)
            {
                IntVector2 newPosition = _movingRandomizer.GetRandomPoint(_motionController.Position);
                _oneUnitController.MoveTo(newPosition);
                return;
            }

            _oneUnitController.Wait(_targetUnit.Position);
            _unitStateInfo.WaitPosition = position;
            _targetUnit.PositionChanged += TargetUnitPositionChanged;
        }

        private void TargetUnitPositionChanged(IntVector2 position)
        {
            _targetUnit.PositionChanged -= TargetUnitPositionChanged;
            if (_unitsTable.IsVacantPosition(_occupiedPoint))
            {
                MoveToDestination(_subMoveController.Destination);
            }
            else
            {
                WaitUnitOnPosition(_occupiedPoint);
            } 
        }

        private void MoveToDestination(IntVector2 destination)
        {
            List<IntVector2> path =
                _pathFinderController.GetPath(_subMoveController.Position, _subMoveController.Destination, null);
            
            _subMoveController.MoveTo(path);
        }
    }
}