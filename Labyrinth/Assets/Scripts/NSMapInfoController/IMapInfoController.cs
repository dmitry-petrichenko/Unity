using NSMapTileInfo;

namespace NSMapInfoController
{
    public interface IMapInfoController
    {
        IMapTileInfo GetMapTileInfo(IntVector2 position);
        void UpdateTileInfo(IMapTileInfo mapTileInfo);
    }
}