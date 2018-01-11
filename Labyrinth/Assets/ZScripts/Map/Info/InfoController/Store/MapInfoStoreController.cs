﻿using System.Collections.Generic;
using System.IO;
using LitJson;
using ZScripts.Settings;

namespace ZScripts.Map.Info
{
    public class MapInfoStoreController : IMapInfoStoreController
    {
        private JsonData infoJson;
        private string jsonString;
        private IMapTileInfo[,] mapInfo;
        private ISettings _settings;

        public MapInfoStoreController(ISettings settings)
        {
            _settings = settings;
        }

        public void SaveMapInfo(IMapTileInfo[,] info, string url)
        {
            MapInfoContainer mapInfoContainer =
                new MapInfoContainer(info, new IntVector2(info.GetLength(0), info.GetLength(1)));

            infoJson = JsonMapper.ToJson(mapInfoContainer);
            File.WriteAllText(_settings.ResiurcesLocation + url, infoJson.ToString());
        }

        public IMapTileInfo[,] UploadMapInfo(string url)
        {
            jsonString = File.ReadAllText(_settings.ResiurcesLocation + url);
            infoJson = JsonMapper.ToObject(jsonString);

            IMapTileInfo[,] returnInfo = CreateReturnInfo();
            List<IMapTileInfo> infoList = UploadTileList();
            InitializeReturnInfo(infoList, returnInfo);

            return returnInfo;
        }

        private void InitializeReturnInfo(List<IMapTileInfo> infoList, IMapTileInfo[,] returnInfo)
        {
            foreach (IMapTileInfo tileInfo in infoList)
            {
                returnInfo[tileInfo.Index.x, tileInfo.Index.y] = tileInfo;
            }
        }

        private IMapTileInfo[,] CreateReturnInfo()
        {
            IntVector2 mapSize = GetIntVector2FromProperty(infoJson, "MapSize");
            IMapTileInfo[,] returnInfo = new IMapTileInfo[mapSize.x, mapSize.y];

            return returnInfo;
        }

        List<IMapTileInfo> UploadTileList()
        {
            List<IMapTileInfo> infoList = new List<IMapTileInfo>();
            MapTileInfo tile;
            infoJson = infoJson["Tiles"];
            int count = infoJson.Count;

            for (int i = 0; i < count; i++)
            {
                tile = new MapTileInfo();
                tile.Initialize((int) infoJson[i]["Type"], GetIntVector2FromProperty(infoJson[i], "ViewPosition"),
                    GetIntVector2FromProperty(infoJson[i], "Index"), null);

                infoList.Add(tile);
            }

            return infoList;
        }

        IntVector2 GetIntVector2FromProperty(JsonData tile, string property)
        {
            IntVector2 intVector2;
            intVector2.x = (int) tile[property]["x"];
            intVector2.y = (int) tile[property]["y"];

            return intVector2;
        }
    }

    public class MapInfoContainer
    {
        public IntVector2 MapSize { get; private set; }
        public IMapTileInfo[,] Tiles { get; private set; }

        public MapInfoContainer(IMapTileInfo[,] Tiles, IntVector2 MapSize)
        {
            this.MapSize = MapSize;
            this.Tiles = Tiles;
        }
    }
}