using System;
using ZScripts;
using ZScripts.Units;
using ZScripts.Units.Player;

namespace Additional.Tests.SectorLoader
{
    public class UnitsControllerMock : IGameEvents
    {
        public void PlayerMoveTo(IntVector2 position)
        {
            
        }

        public void UpdatePosition(IntVector2 position)
        {
            if (PlayerPositionChanged != null)
                PlayerPositionChanged(position);
        }

        public IntVector2 PlayerPosition { get; private set; }
        public event Action<IntVector2> PlayerPositionChanged;
        public void TriggerPlayerPositionChanged(IntVector2 position)
        {
            
        }
    }
}