using Labyrinth.Map;
using Units;

namespace ZScripts.Map.Info
{
    public interface IMapTileInfo : ITileView
    {
        UnitController UnitContainer { get; set; }
        IntVector2 Index { get; set; }
    }
}