using System;
using System.Collections.Generic;
using Units;
using ZScripts.Units.PathFinder;

namespace ZScripts.Units
{
    public class OneUnitController : IOneUnitController
    {
        public IOneUnitGraphicsController GraphicsController { get; set; }
        public IOneUnitAnimationController AnimationController { get; set; }

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

        public void Initialize(IOneUnitGraphicsController GraphicsController, IOneUnitAnimationController animationController)
        {
            this.GraphicsController = GraphicsController;
            this.AnimationController = animationController;
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