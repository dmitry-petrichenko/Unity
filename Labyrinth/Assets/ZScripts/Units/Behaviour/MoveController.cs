using System;
using System.Collections.Generic;
using Labyrinth;
using ZScripts.Units.PathFinder;

namespace ZScripts.Units
{
    public class MoveController
    {
        private IOneUnitController _unitController;
        private List<IntVector2> _path;
        private readonly IPathFinderController _pathFinderController;

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
            // TODO hide in interface 
            _unitController.GraphicsController.CompleteMove += MoveNextStep;
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
                _unitController.GraphicsController.MoveToPosition(nextPosition);
                _unitController.AnimationController.PlayWalkAnimation();
            }
            else
            {
                _unitController.AnimationController.PlayIdleAnimation();
                _unitController.GraphicsController.CompleteMove -= MoveNextStep;
            }
        }
    }
}