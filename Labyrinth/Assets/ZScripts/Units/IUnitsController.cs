using System;

namespace ZScripts.Units
{
    public interface IUnitsController
    {
        void PlayerMoveTo(IntVector2 position);
        IntVector2 PlayerPosition { get; }
        event Action<IntVector2> PlyerPositionChanged;
    }
}