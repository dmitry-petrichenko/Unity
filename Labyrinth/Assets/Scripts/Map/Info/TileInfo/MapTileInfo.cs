using Labyrinth;
using NSUnits;

namespace Map
{
    public class MapTileInfo : IMapTileInfo
    {
        public MapTileType Type { get; set; }
        public Unit UnitContainer { get; set; }
        public IntVector2 ViewPosition { get; set; }
        public IntVector2 Index { get; set; }

        public void Initialize(MapTileType Type, IntVector2 ViewPosition, IntVector2 Index, Unit UnitContainer)
        {
            this.Index = Index;
            this.UnitContainer = UnitContainer;
            this.Type = Type;
            this.ViewPosition = ViewPosition;
        }
    }
}