using System;
using Labyrinth;

namespace Map
{
    public interface IMapInfoStoreController
    {
        void SaveMapInfo(IMapTileInfo[,] info, String url);
        IMapTileInfo[,] UploadMapInfo(String url);
    }
}