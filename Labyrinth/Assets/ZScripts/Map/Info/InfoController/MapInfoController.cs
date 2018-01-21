using System.Collections.Generic;
using ZScripts.Settings;

namespace ZScripts.Map.Info
{
    public class MapInfoController : IMapInfoController
    {
        private Dictionary<IntVector2, IMapTileInfo> _mapTilesInfo = new Dictionary<IntVector2, IMapTileInfo>();
        private IMapInfoInitializer _mapInfoInitializer;
        private MapInfoStoreController _mapInfoStoreController;
        private ISettings _settings;

        public MapInfoController(ISettings settings)
        {
            _settings = settings;
            Initialize();
        }

        public void Initialize()
        {
            _mapInfoStoreController = new MapInfoStoreController(_settings);
            _mapTilesInfo = _mapInfoStoreController.UploadSectorData(new IntVector2(0, 0));

            _mapInfoInitializer = new MapInfoInitializer();
            //_mapInfoInitializer.InitializeSector(_mapTilesInfo);
        }

        public IMapTileInfo GetMapTileInfo(IntVector2 position)
        {
            if (_mapTilesInfo.ContainsKey(position))
            {
                return _mapTilesInfo[position];
            }
            else
            {
                return _mapInfoInitializer.CreateEmptyTileInfo(position);
            }
        }

        public void UpdateMapTileInfo(IMapTileInfo mapTileInfo)
        {
        }

        public Dictionary<IntVector2, IMapTileInfo> MapTilesInfo
        {
            get { return _mapTilesInfo; }
        }
    }
}