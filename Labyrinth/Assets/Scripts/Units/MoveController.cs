using System;
using Labyrinth;

namespace Units
{
    public class MoveController
    {
        private IUnitController _unitController;

        event Action CompleteMove;

        public void Initialize(IUnitController unitController)
        {
            _unitController = unitController;
        }

        public void MoveTo(IntVector2 position)
        {
            _unitController.GraphicsController.MoveToPosition(position);
        }
    }
}