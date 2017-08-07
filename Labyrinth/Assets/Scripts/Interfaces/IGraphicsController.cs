using Labyrinth;

namespace NSGraphics
{
    public delegate void TileClickHandler(IntVector2 position);

    public interface IGraphicsController
    {
        void InitializePlane(IntVector2 position);
        void InitializeCube(IntVector2 position);
        void InitializeEmpty(IntVector2 position);
        void InitializeSquare(IntVector2 position);
        void DestroyTile(IntVector2 position);
        
        event TileClickHandler TileClicked;
    }
}