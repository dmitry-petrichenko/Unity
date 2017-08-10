using Map;
using Units;

namespace Labyrinth
{
    public interface IMapTileInfo : ITileView
    {
        Unit UnitContainer { get; set; }
        IntVector2 Index { get; set; }
    }
}