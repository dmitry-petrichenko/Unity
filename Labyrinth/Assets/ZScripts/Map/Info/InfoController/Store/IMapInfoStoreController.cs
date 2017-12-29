using System;

namespace ZScripts.Map.Info
{
    public interface IMapInfoStoreController
    {
        void SaveMapInfo(IMapTileInfo[,] info, String url);
        IMapTileInfo[,] UploadMapInfo(String url);
    }
}