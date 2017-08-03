namespace NSGraphics
{
    public interface IGraphicsController
    {
        void InitializePlane(IntVector2 position);
        void InitializeCube(IntVector2 position);
        void InitializeEmpty(IntVector2 position);
    }
}