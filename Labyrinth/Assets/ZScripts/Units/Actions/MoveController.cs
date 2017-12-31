using System;
using System.Collections.Generic;
using Labyrinth;

namespace ZScripts.Units
{
    public class MoveController
    {
        private IOneUnitController _unitController;
        private List<IntVector2> _path;

        event Action CompleteMove;

        public MoveController()
        {
            
        }

        public void Initialize(IOneUnitController unitController)
        {
            _unitController = unitController;
        }

        public void MoveTo(List<IntVector2> path)
        {
            _path = path;
            // TODO hide in interface 
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