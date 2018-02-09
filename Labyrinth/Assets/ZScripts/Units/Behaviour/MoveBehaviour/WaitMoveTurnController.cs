using System.Collections.Generic;
using UnityEngine;
using ZScripts.Units.PathFinder;
using ZScripts.Units.Player;

namespace ZScripts.Units
{
    public class WaitMoveTurnController
    {
        private IOneUnitServicesContainer _oneUnitController;
        private readonly IUnitsTable _unitsTable;
        private IOneUnitController _targetUnit;
        private IPathFinderController _pathFinderController;
        private IntVector2 _occupiedPoint;
        
        public WaitMoveTurnController(
            IUnitsTable unitsTable,
            IPathFinderController pathFinderController
            )
        {
            _unitsTable = unitsTable;
            _pathFinderController = pathFinderController;
        }
        
        private ISubMoveController _subMoveController;
        
        public void Initialize(ISubMoveController subMoveController, IOneUnitServicesContainer oneUnitController)
        {
            _oneUnitController = oneUnitController;
            _subMoveController = subMoveController;
            _subMoveController.NoWayToPointHandler += NoWayToPointHandler;
        }

        private void NoWayToPointHandler(IntVector2 occupiedPoint)
        {
            _occupiedPoint = occupiedPoint;
            _oneUnitController.AnimationController.PlayIdleAnimation();
            WaitUnitOnPosition(_occupiedPoint);
            
            Debug.Log("NoWayToPointHandler");
        }

        private void WaitUnitOnPosition(IntVector2 position)
        {
            _targetUnit = _unitsTable.GetUnitOnPosition(position);
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