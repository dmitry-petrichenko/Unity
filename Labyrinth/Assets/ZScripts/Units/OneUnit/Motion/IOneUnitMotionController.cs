using System;
using UnityEngine;

namespace ZScripts.Units
{
    public interface IOneUnitMotionController
    {
        void MoveToPosition(IntVector2 position);
        void Wait();
        IntVector2 Position { get; }
        void Initialize(GameObject unit, IOneUnitController oneUnitController);
        bool IsMoving { get; }

        event Action CompleteMove;
    }
}