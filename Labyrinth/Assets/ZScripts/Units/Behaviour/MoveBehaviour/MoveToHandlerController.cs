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

        public MoveToHandlerController(IPathFinderController pathFinderController)
        {
            _pathFinderController = pathFinderController;
        }
        
        public void Initialize(ISubMoveController subMoveController)
        {
            _subMoveController = subMoveController;
        }

        public void MoveTo(IntVector2 position)
        {
            if (_subMoveController.IsMoving)
            {
                Debug.Log("_newPosition" + " " + position.x + " " + position.y);
                _newPosition = position;
                ChangeDirrection();
            }
            else
            {
                Debug.Log("MoveToDirrection" + " " + position.x + " " + position.y);
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
            Debug.Log("OnChangeDirrectionMoveCmplete");
            _subMoveController.MoveStepComplete -= OnChangeDirrectionMoveCmplete;
            MoveToDirrection(_newPosition);
        }
    }
}