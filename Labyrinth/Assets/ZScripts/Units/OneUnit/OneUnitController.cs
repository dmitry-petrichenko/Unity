using System;
using System.Collections.Generic;
using ZScripts.Units.PathFinder;

namespace ZScripts.Units
{
    public class OneUnitController : IOneUnitController
    {
        public IOneUnitGraphicsController GraphicsController { get; set; }

        private MoveController _moveController;
        private AttackController _attackController;
        
        public event Action<IntVector2> PositionChanged;

        public OneUnitController(
            MoveController moveController, 
            AttackController attackController)
        {
            _moveController = moveController;
            _attackController = attackController;
        }

        public void Initialize(IOneUnitGraphicsController GraphicsController)
        {
            this.GraphicsController = GraphicsController;
            GraphicsController.CompleteMove += UpdatePosition;

            _moveController.Initialize(this);
            _attackController.Initialize(this);
        }

        public void MoveTo(IntVector2 position)
        {
            _moveController.MoveTo(position);
        }

        private void UpdatePosition()
        {
            if (PositionChanged != null)
                PositionChanged(Position);
        }

        public IntVector2 Position
        {
            get { return GraphicsController.Position; }
        }
    }
}