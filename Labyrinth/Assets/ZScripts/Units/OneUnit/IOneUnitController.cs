﻿using System;
using Labyrinth;

namespace ZScripts.Units
{
    public interface IOneUnitController
    {
        IOneUnitGraphicsController GraphicsController { get; set; }
        IntVector2 Position { get; set;  }
        event Action PositionChanged;
        void Initialize(IOneUnitGraphicsController GraphicsController);
        void MoveTo(IntVector2 position);
    }
}