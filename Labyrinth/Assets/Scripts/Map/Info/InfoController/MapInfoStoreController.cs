using System.IO;
using Labyrinth;
using LitJson;
using UnityEngine;

namespace Map
{
    public class MapInfoStoreController : IMapInfoStoreController
    {
        private JsonData infoJson;
        private string jsonString;
        private IMapTileInfo[,] mapInfo;
        
        public void SaveMapInfo(IMapTileInfo[,] info, string url)
        {
            infoJson = JsonMapper.ToJson(info);
            File.WriteAllText(Application.dataPath + "/info.json", infoJson.ToString());
        }

        public IMapTileInfo[,] UploadMapInfo(string url)
        {
            jsonString = File.ReadAllText(Application.dataPath + "/info.json");
            infoJson = JsonMapper.ToObject(jsonString);
            return null;
        }
    }
}