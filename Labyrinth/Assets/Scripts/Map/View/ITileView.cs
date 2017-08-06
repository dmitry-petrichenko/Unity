using Labyrinth;

namespace Map
{
    public interface ITileView
    {
        IntVector2 ViewPosition { get; set; }
        MapTileType Type { get; set; }
    }
}