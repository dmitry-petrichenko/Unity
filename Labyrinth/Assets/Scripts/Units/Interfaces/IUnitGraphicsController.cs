using System;
using Labyrinth;
using UnityEngine;

namespace Units
{
    public interface  IUnitGraphicsController
    {
        void MoveToPosition(IntVector2 position);
        void Wait();
        
        event Action CompleteMove;
    }
}