using System;
using ZScripts;
using ZScripts.Units;

namespace Additional.Tests.SectorLoader
{
    public class UnitsControllerMock : IUnitsController
    {
        public void PlayerMoveTo(IntVector2 position)
        {
            
        }

        public void UpdatePosition(IntVector2 position)
        {
            if (PlyerPositionChanged != null)
                PlyerPositionChanged(position);
        }

        public IntVector2 PlayerPosition { get; private set; }
        public event Action<IntVector2> PlyerPositionChanged;
    }
}