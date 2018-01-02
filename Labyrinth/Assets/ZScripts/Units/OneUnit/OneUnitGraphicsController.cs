using System;
using DG.Tweening;
using Labyrinth;
using UnityEngine;

namespace ZScripts.Units
{
    public class OneUnitGraphicsController : IOneUnitGraphicsController
    {
        private GameObject _unit;
        public IntVector2 Position { get; private set; }

        public OneUnitGraphicsController()
        {
            
        }

        public void Initialize(GameObject unit)
        {
            _unit = unit;
            Position = new IntVector2((int)_unit.transform.position.x, (int)_unit.transform.position.z);
        }

        public void MoveToPosition(IntVector2 position)
        {
            _unit.transform.DOMove(new Vector3(position.x, 0, position.y), 0.7f)
                .OnComplete(CompleteMoveHandler)
                .SetEase(Ease.Linear);
        }

        private void CompleteMoveHandler()
        {
            Position = new IntVector2((int)_unit.transform.position.x, (int)_unit.transform.position.z);
            if (CompleteMove != null)
                CompleteMove();
        }

        public void Wait()
        {
        }

        public event Action CompleteMove;
    }
}