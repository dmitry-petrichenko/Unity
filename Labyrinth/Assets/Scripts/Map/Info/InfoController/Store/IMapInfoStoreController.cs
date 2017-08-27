using System;

namespace Labyrinth.Map
{
    public interface IMapInfoStoreController
    {
        void SaveMapInfo(IMapTileInfo[,] info, String url);
        IMapTileInfo[,] UploadMapInfo(String url);
    }
}