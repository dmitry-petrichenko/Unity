using System;
using System.Collections.Generic;
using Labyrinth;

namespace Units
{
    public class MoveController
    {
        private IUnitController _unitController;

        event Action CompleteMove;

        private List<IntVector2> _path;

        public void Initialize(IUnitController unitController)
        {
            _unitController = unitController;
        }

        public void MoveTo(List<IntVector2> path)
        {
            _path = path;
            _unitController.GraphicsController.CompleteMove += MoveNextStep;
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
                _unitController.Position = nextPosition;
            }
            else
            {
                _unitController.GraphicsController.CompleteMove -= MoveNextStep;
            }
        }
    }
}