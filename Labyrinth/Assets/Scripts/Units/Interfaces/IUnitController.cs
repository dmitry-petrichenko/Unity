using System;
using Labyrinth;

namespace Units
{
    public interface IUnitController
    {
        IUnitGraphicsController GraphicsController { get; set; }
        IntVector2 Position { get; set;  }
        event Action PositionChanged;
    }
}