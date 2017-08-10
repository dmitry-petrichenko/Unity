using System;
using DG.Tweening;
using Labyrinth;
using UnityEngine;

namespace Units
{
    public class UnitGraphicsController : IUnitGraphicsController
    {
        private GameObject _unit;

        public void Initialize(GameObject unit)
        {
            _unit = unit;
        }
        
        public void MoveToPosition(IntVector2 position)
        {
            _unit.transform.DOMove(new Vector3(position.x, 0, position.y), 1f);
        }

        public void Wait()
        {
            
        }

        public event Action CompleteMove;
    }
}