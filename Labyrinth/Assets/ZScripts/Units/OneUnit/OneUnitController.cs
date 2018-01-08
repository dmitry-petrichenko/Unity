using System;
using System.Collections.Generic;
using Units;
using Zenject;
using ZScripts.Units.PathFinder;
using ZScripts.Units.Rotation;

namespace ZScripts.Units
{
    public class OneUnitController : IOneUnitController
    {
        public IOneUnitMotionController MotionController { get; set; }
        public IOneUnitAnimationController AnimationController { get; set; }
        public IOneUnitRotationController RotationController { get; set; }

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

        public void Initialize(
            IOneUnitMotionController MotionController, 
            IOneUnitAnimationController animationController,
            IOneUnitRotationController oneUnitRotationController
            )
        {
            this.MotionController = MotionController;
            this.AnimationController = animationController;
            this.RotationController = oneUnitRotationController;
            MotionController.CompleteMove += UpdatePosition;

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
            get { return MotionController.Position; }
        }
    }
}