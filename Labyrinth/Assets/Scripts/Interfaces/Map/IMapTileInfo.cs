using Labyrinth.Map;
using Units;

namespace Labyrinth
{
    public interface IMapTileInfo : ITileView
    {
        UnitController UnitContainer { get; set; }
        IntVector2 Index { get; set; }
    }
}