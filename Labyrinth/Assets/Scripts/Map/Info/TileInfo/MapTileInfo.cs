using Units;

namespace Labyrinth.Map
{
    public class MapTileInfo : IMapTileInfo
    {
        public int Type { get; set; }
        public UnitController UnitContainer { get; set; }
        public IntVector2 ViewPosition { get; set; }
        public IntVector2 Index { get; set; }

        public void Initialize(int Type, IntVector2 ViewPosition, IntVector2 Index, UnitController UnitContainer)
        {
            this.Index = Index;
            this.UnitContainer = UnitContainer;
            this.Type = Type;
            this.ViewPosition = ViewPosition;
        }
    }
}