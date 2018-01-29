using System;
using System.Collections.Generic;
using ZScripts.Units.PathFinder;

namespace ZScripts.Units
{
    public class MoveController
    {
        private IOneUnitController _unitController;
        private List<IntVector2> _path;
        private readonly IPathFinderController _pathFinderController;
        private IntVector2 _newPosition;

        event Action CompleteMove;

        public MoveController(IPathFinderController pathFinderController)
        {
            _pathFinderController = pathFinderController;
        }

        public void Initialize(IOneUnitController unitController)
        {
            _unitController = unitController;
        }

        public void MoveTo(IntVector2 position)
        {
            if (_unitController.MotionController.IsMoving)
            {
                _newPosition = position;
                ChangeDirrection();
            }
            else
            {
                MoveToDirrection(position);
            }

        }

        private void ChangeDirrection()
        {
            _unitController.MotionController.CompleteMove -= MoveNextStep;
            _unitController.MotionController.CompleteMove += OnChangeDirrectionMoveCmplete;
        }

        private void OnChangeDirrectionMoveCmplete()
        {
            _unitController.MotionController.CompleteMove -= OnChangeDirrectionMoveCmplete;
            MoveToDirrection(_newPosition);
        }

        private void MoveToDirrection(IntVector2 position)
        {
            _unitController.MotionController.CompleteMove += MoveNextStep;
            _path = _pathFinderController.GetPath(_unitController.Position, position);
            MoveNextStep();
        }

        private void MoveNextStep()
        {
            IntVector2 nextPosition;
            
            if (_path.Count > 0)
            {
                nextPosition = _path[0];
                _path.RemoveAt(0);
                _unitController.MotionController.MoveToPosition(nextPosition);
                _unitController.AnimationController.PlayWalkAnimation();
                _unitController.RotationController.Rotate(_unitController.Position, nextPosition);
            }
            else
            {
                _unitController.AnimationController.PlayIdleAnimation();
                _unitController.MotionController.CompleteMove -= MoveNextStep;
            }
        }
    }
}