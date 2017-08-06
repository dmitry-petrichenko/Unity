using Map;
using NSUnits;

namespace Labyrinth
{
    public interface IMapTileInfo
    {
        MapTileType Type { get; set; }
        Unit UnitContainer { get; set; }
        IntVector2 ViewPosition { get; set; }
        IntVector2 Index { get; set; }
    }
}