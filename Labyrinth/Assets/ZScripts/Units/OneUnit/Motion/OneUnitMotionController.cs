using System;
using DG.Tweening;
using UnityEngine;
using ZScripts.Units.Settings;

namespace ZScripts.Units
{
    public class OneUnitMotionController : IOneUnitMotionController
    {
        private GameObject _unit;
        private IUnitSettings _unitSettings;
        
        public IntVector2 Position { get; private set; }
        public bool IsMoving { get; private set; }

        public void SetOnPosition(IntVector2 position)
        {
            _unit.transform.position = new Vector3(position.x, 0, position.y);
            Position = position;
        }   

        public void Initialize(IUnitSettings unitSettings)
        {
            _unitSettings = unitSettings;
            _unit = _unitSettings.GraphicObject;
        }

        public void MoveToPosition(IntVector2 position)
        {
            IsMoving = true;
            _unit.transform.DOMove(new Vector3(position.x, 0, position.y), _unitSettings.MotionSpeed)
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