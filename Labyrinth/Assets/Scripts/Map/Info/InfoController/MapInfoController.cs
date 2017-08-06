using Labyrinth;

namespace Map
{
    public class MapInfoController : IMapInfoController
    {
        private IMapTileInfo[,] _mapTilesInfo;
        private MapInfoInitializer _mapInfoInitializer;
        
        private IntVector2 _mapSize;

        public MapInfoController()
        {
            
        }

        public void Initialize()
        {
            _mapSize = new IntVector2(10, 10);
            _mapInfoInitializer = new MapInfoInitializer();
            _mapInfoInitializer.Initialize(_mapSize);

            _mapTilesInfo = _mapInfoInitializer.MapTilesInfo;
        }
        
        public IMapTileInfo GetMapTileInfo(IntVector2 position)
        {
            if (position.x >= _mapSize.x || position.y >= _mapSize.y)
            {
                return _mapInfoInitializer.InitializeEmptyTileInfo(position);
            }

            if (position.x < 0 || position.y < 0)
            {
                return _mapInfoInitializer.InitializeEmptyTileInfo(position);
            }
            
            return _mapTilesInfo[position.x, position.y];
        }

        public void UpdateTileInfo(IMapTileInfo mapTileInfo)
        {
            
        }
    }
}