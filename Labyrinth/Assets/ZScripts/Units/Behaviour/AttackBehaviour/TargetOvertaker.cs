using System;
using System.Collections.Generic;
using ZScripts.Units.PathFinder;

namespace ZScripts.Units
{
    public class TargetOvertaker : EventDispatcher
    {
        public event Action Complete;
        public event Action StartFollow;
        public event Action TargetMoved;
        
        private IOneUnitController _target;
        private IOneUnitController _oneUnitController;
        
        private readonly IPathFinderController _pathFinderController;

        public TargetOvertaker(IPathFinderController pathFinderController)
        {
            _pathFinderController = pathFinderController;
        }

        public void Initialize(IOneUnitController oneUnitController)
        {
            _oneUnitController = oneUnitController;
        }
        
        public void Overtake(IOneUnitController target)
        {
            _target = target;
            _target.PositionChanged += OnTargetPositionChanged;
            _oneUnitController.CompleteMoveTo += OnUnitCompleteMoveTo;
            
            MoveToTarget();
        }

        private void OnUnitCompleteMoveTo()
        {
            _oneUnitController.CompleteMoveTo -= OnUnitCompleteMoveTo;
        }

        private void OnTargetPositionChanged(IntVector2 position)
        {
            if (PositionInUnitRange(position))
            {
                DispatchEvent(TargetMoved);
            }
            else
            {
                DispatchEvent(StartFollow);
                MoveToTarget();
            }
        }

        private void MoveToTarget()
        {
            List<IntVector2> path =
                _pathFinderController.GetPath(_target.Position, _oneUnitController.Position, 1);
            
            _oneUnitController.MoveTo(path[0]);
        }

        private bool PositionInUnitRange(IntVector2 position)
        {
            return false;
        }

        public void Cancel()
        {
            _target.PositionChanged -= OnTargetPositionChanged;
        }
    }
}