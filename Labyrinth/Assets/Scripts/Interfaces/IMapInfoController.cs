namespace Labyrinth
{
    public interface IMapInfoController
    {
        IMapTileInfo GetMapTileInfo(IntVector2 position);
        void UpdateTileInfo(IMapTileInfo mapTileInfo);
    }
}