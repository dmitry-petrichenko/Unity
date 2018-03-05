using System.Collections.Generic;
using UnityEngine;
using ZScripts.Units.PathFinder;

namespace ZScripts.Units
{
    public class MoveToHandlerController
    {
        private ISubMoveController _subMoveController;
        private IntVector2 _newPosition;
        private IPathFinderController _pathFinderController;

        public MoveToHandlerController(
            IPathFinderController pathFinderController,
            ISubMoveController subMoveController)
        {
            _subMoveController = subMoveController;
            _pathFinderController = pathFinderController;
        }

        public void MoveTo(IntVector2 position)
        {
            if (_subMoveController.IsMoving)
            {
                _newPosition = position;
                ChangeDirrection();
            }
            else
            {
                MoveToDirrection(position);
            }
        }

        private void MoveToDirrection(IntVector2 position)
        {
            List<IntVector2> path = _pathFinderController.GetPath(_subMoveController.Position, position, null);
            _subMoveController.Destination = position;
            _subMoveController.MoveTo(path);
        }
        
        private void ChangeDirrection()
        {
            _subMoveController.MoveStepComplete -= OnChangeDirrectionMoveCmplete;
            _subMoveController.Cancel();
            _subMoveController.MoveStepComplete += OnChangeDirrectionMoveCmplete;
        }
        
        private void OnChangeDirrectionMoveCmplete()
        {
            _subMoveController.MoveStepComplete -= OnChangeDirrectionMoveCmplete;
            MoveToDirrection(_newPosition);
        }
    }
}