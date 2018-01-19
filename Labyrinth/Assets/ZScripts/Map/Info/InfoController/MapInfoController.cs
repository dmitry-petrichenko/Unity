using ZScripts.Settings;

namespace ZScripts.Map.Info
{
    public class MapInfoController : IMapInfoController
    {
        private IMapTileInfo[,] _mapTilesInfo;
        private IMapInfoInitializer _mapInfoInitializer;
        private MapInfoStoreController _mapInfoStoreController;
        private MapInfoCommon _mapInfoCommon;
        private ISettings _settings;

        public MapInfoController(ISettings settings)
        {
            _settings = settings;
            Initialize();
        }

        public void Initialize()
        {
            _mapInfoStoreController = new MapInfoStoreController(_settings);
            _mapTilesInfo = _mapInfoStoreController.UploadMapInfo("/test.json");
            
            _mapInfoCommon = new MapInfoCommon();
            _mapInfoCommon.MapWidth = _mapTilesInfo.GetLength(0);
            _mapInfoCommon.MapHeight = _mapTilesInfo.GetLength(1);
                        
            _mapInfoInitializer = new MapInfoInitializer();
            _mapInfoInitializer.InitializeSector(_mapTilesInfo);
        }

        public IMapTileInfo GetMapTileInfo(IntVector2 position)
        {
            if (position.x >= _mapInfoCommon.MapWidth || position.y >= _mapInfoCommon.MapHeight)
            {
                return _mapInfoInitializer.CreateEmptyTileInfo(position);
            }

            if (position.x < 0 || position.y < 0)
            {
                return _mapInfoInitializer.CreateEmptyTileInfo(position);
            }

            return _mapTilesInfo[position.x, position.y];
        }

        public void UpdateMapTileInfo(IMapTileInfo mapTileInfo)
        {
        }

        public IMapInfoCommon MapInfoCommon
        {
            get { return _mapInfoCommon; }
        }
    }
}