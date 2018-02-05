using System;
using DG.Tweening;
using UnityEngine;
using ZScripts.GameLoop;
using ZScripts.Units.Settings;

namespace ZScripts.Units
{
    public class OneUnitMotionController : IOneUnitMotionController
    {
        private GameObject _unit;
        private IUnitSettings _unitSettings;
        
        public IntVector2 Position { get; private set; }
        public bool IsMoving { get; private set; }

        private readonly IOccupatedPossitionsTable _occupatedPossitionsTable;

        private IGameLoopController _glp;

        public OneUnitMotionController(IOccupatedPossitionsTable occupatedPossitionsTable, IGameLoopController glp)
        {
            _occupatedPossitionsTable = occupatedPossitionsTable;
            _glp = glp;
        }

        public void SetOnPosition(IntVector2 position)
        {
            _unit.transform.position = new Vector3(position.x, 0, position.y);
            Position = position;
            _occupatedPossitionsTable.SetOccupied(Position);
        }   

        public void Initialize(IUnitSettings unitSettings)
        {
            _unitSettings = unitSettings;
            _unit = _unitSettings.GraphicObject;
        }

        public void MoveToPosition(IntVector2 position)
        {
            IsMoving = true;
            float motionSpeed;
            
            if (IsDiagonal(Position, position))
            {
                motionSpeed = _unitSettings.MotionSpeed * 1.4f;
            }
            else
            {
                motionSpeed = _unitSettings.MotionSpeed;
            }
            
            _glp.DelayStart(CompleteMoveHandler, motionSpeed);
            _unit.transform.position = new Vector3(position.x, 0, position.y);
            //_unit.transform.DOMove(new Vector3(position.x, 0, position.y), motionSpeed)
            //   .OnComplete(CompleteMoveHandler)
            //   .SetEase(Ease.Linear);
        }

        private bool IsDiagonal(IntVector2 position1, IntVector2 position2)
        {
            if (position1.x == position2.x || position1.y == position2.y)
            {
                return false;
            }
            else
            {
                return true;
            }
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