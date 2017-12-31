using System;
using Labyrinth;
using UnityEngine;

namespace ZScripts.Units
{
    public interface IOneUnitGraphicsController
    {
        void MoveToPosition(IntVector2 position);
        void Wait();
        IntVector2 Position { get; }
        void Initialize(GameObject unit);

        event Action CompleteMove;
    }
}