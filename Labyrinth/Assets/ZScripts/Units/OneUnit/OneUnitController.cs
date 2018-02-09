using System;
using Units;
using UnityEngine;
using Zenject;
using ZScripts.Units.Rotation;
using ZScripts.Units.Settings;

namespace ZScripts.Units
{
    public class OneUnitController : OneUnitServicesContainer, IOneUnitController
    {
        public event Action<IntVector2> PositionChanged;
        public event Action CompleteMoveTo;

        private MoveController _moveController;
        private AttackController _attackController;
        private IUnitsTable _unitsTable;
        
        [Inject]
        void Construct(
            MoveController moveController, 
            AttackController attackController,
            IUnitsTable unitsTable
            )
        {
            _unitsTable = unitsTable;
            _moveController = moveController;
            _attackController = attackController;
        }

        protected void Initialize()
        {
            base.Initialize();            
            // Initialize behaviour
            _moveController.Initialize(this);
            _moveController.MoveOneStepComplete += UpdatePosition;
            _moveController.MoveToComplete += MoveCompleteHandler;
            _attackController.Initialize(this);
            _unitsTable.AddUnit(this);
        }

        private void MoveCompleteHandler()
        {
            if (CompleteMoveTo != null)
            {
                CompleteMoveTo();
            }
        }

        public void SetOnPosition(IntVector2 position)
        {
            _moveController.SetOnPosition(position);
        }

        protected virtual void UpdatePosition()
        {
            if (PositionChanged != null)
                PositionChanged(Position);
        }

        public IntVector2 Position
        {
            get { return MotionController.Position; }
        }

        public void MoveTo(IntVector2 position)
        {
            _moveController.MoveTo(position);
        }

        public void Wait()
        {
            AnimationController.PlayIdleAnimation();
        }
    }
}