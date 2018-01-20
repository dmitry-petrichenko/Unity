using System.Collections.Generic;

namespace ZScripts.Map.Info
{
    public interface IMapInfoController
    {
        IMapTileInfo GetMapTileInfo(IntVector2 position);
        void UpdateMapTileInfo(IMapTileInfo mapTileInfo);
        Dictionary<IntVector2, IMapTileInfo> MapTilesInfo { get; }
    }
}