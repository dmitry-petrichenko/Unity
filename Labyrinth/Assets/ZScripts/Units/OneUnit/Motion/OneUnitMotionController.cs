using System;
using DG.Tweening;
using UnityEngine;

namespace ZScripts.Units
{
    public class OneUnitMotionController : IOneUnitMotionController
    {
        private GameObject _unit;
        private IOneUnitController _unitController;
        public IntVector2 Position { get; private set; }
        public bool IsMoving { get; private set; }

        public OneUnitMotionController()
        {
            
        }

        public void Initialize(GameObject unit, IOneUnitController unitController)
        {
            _unitController = unitController;
            _unit = unit;
            Position = new IntVector2((int)_unit.transform.position.x, (int)_unit.transform.position.z);
        }

        public void MoveToPosition(IntVector2 position)
        {
            IsMoving = true;
            _unit.transform.DOMove(new Vector3(position.x, 0, position.y), _unitController.UnitSettings.MotionSpeed)
                .OnComplete(CompleteMoveHandler)
                .SetEase(Ease.Linear);
        }

        private void CompleteMoveHandler()
        {
            Position = new IntVector2((int)_unit.transform.position.x, (int)_unit.transform.position.z);
            IsMoving = false;
            if (CompleteMove != null)
                CompleteMove();
        }

        public void Wait()
        {
        }

        public event Action CompleteMove;
    }
}