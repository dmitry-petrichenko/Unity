using System;
using System.Collections.Generic;

namespace ZScripts.Units
{
    public interface ISubMoveController
    {
        void MoveTo(List<IntVector2> path);
        void Cancel();
        void Initialize(IOneUnitServicesContainer oneUnitServicesContainer);
        
        IntVector2 Position { get; }
        bool IsMoving { get; }
        IntVector2 Destination { get; set; }

        event Action MoveToComplete;
        event Action NextPositionOccupiedHandler;
        event Action MoveStepComplete;
    }
}