using System;
using Labyrinth;

namespace Units
{
    public interface IUnitGraphicsController
    {
        void MoveToPosition(IntVector2 position);
        void Wait();
        IntVector2 Position { get; }

        event Action CompleteMove;
    }
}