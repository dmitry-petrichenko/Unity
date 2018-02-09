﻿using System;
using System.Collections.Generic;

namespace ZScripts.Units
{
    public interface ISubMoveController
    {
        void MoveTo(List<IntVector2> path);
        void Cancel();
        void Initialize(IOneUnitServicesContainer oneUnitServicesContainer);
        void SetOnPosition(IntVector2 position);
        
        IntVector2 Position { get; }
        bool IsMoving { get; }
        IntVector2 Destination { get; set; }

        event Action MoveToComplete;
        event Action<IntVector2> NextPositionOccupiedHandler;
        event Action MoveStepComplete;
        event Action<IntVector2> NoWayToPointHandler;
    }
}