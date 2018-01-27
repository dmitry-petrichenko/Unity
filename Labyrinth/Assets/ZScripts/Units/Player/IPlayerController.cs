using System;

namespace ZScripts.Units.Player
{
    public interface IPlayerController  : IOneUnitController
    {
        event Action<IntVector2> PositionChanged;
    }
}