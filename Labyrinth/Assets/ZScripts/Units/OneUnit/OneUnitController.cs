using System;
using Units;
using UnityEngine;
using Zenject;
using ZScripts.Units.Rotation;
using ZScripts.Units.Settings;

namespace ZScripts.Units
{
    public class OneUnitController : IOneUnitController
    {
        public event Action<IntVector2> PositionChanged;
        
        private IOneUnitMotionController _oneUnitMotionController;
        private IOneUnitAnimationController _oneUnitAnimationController;
        private IOneUnitRotationController _oneUnitRotationController;
        private MoveController _moveController;
        private AttackController _attackController;
        
        [Inject]
        void Construct(
            IOneUnitMotionController oneUnitMotionController,
            IOneUnitAnimationController oneUnitAnimationController,
            IOneUnitRotationController oneUnitRotationController,
            MoveController moveController, 
            AttackController attackController)
        {
            _oneUnitRotationController = oneUnitRotationController;
            _oneUnitMotionController = oneUnitMotionController;
            _oneUnitAnimationController = oneUnitAnimationController;
            _moveController = moveController;
            _attackController = attackController;
        }

        protected void Initialize()
        {
            _oneUnitMotionController.Initialize(UnitSettings);
            _oneUnitAnimationController.Initialize(UnitSettings);
            _oneUnitRotationController.Initialize(UnitSettings);

            MotionController = _oneUnitMotionController;
            AnimationController = _oneUnitAnimationController;
            RotationController = _oneUnitRotationController;
            MotionController.CompleteMove += UpdatePosition;
            
            // Initialize behaviour
            _moveController.Initialize(this);
            _attackController.Initialize(this);
        }

        public void SetOnPosition(IntVector2 position)
        {
            MotionController.SetOnPosition(position);
        }

        protected virtual void UpdatePosition()
        {
            if (PositionChanged != null)
                PositionChanged(Position);
        }

        public IOneUnitMotionController MotionController { get; set; }
        public IOneUnitAnimationController AnimationController { get; set; }
        public IOneUnitRotationController RotationController { get; set; }
        public IUnitSettings UnitSettings { get; set; }

        public IntVector2 Position
        {
            get { return _oneUnitMotionController.Position; }
        }

        public void MoveTo(IntVector2 position)
        {
            _moveController.MoveTo(position);
        }   
    }
}