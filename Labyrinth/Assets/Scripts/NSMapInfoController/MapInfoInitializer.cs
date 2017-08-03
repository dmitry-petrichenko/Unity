using NSMapTileInfo;

namespace NSMapInfoController
{
    public class MapInfoInitializer
    {
        private IMapTileInfo[,] _mapTilesInfo;

        public IMapTileInfo[,] MapTilesInfo {
            get { return _mapTilesInfo; }
        }

        public void Initialize(IntVector2 mapArea)
        {
            mapArea.x = 10;
            mapArea.y = 10;
            
            _mapTilesInfo = new IMapTileInfo[mapArea.x, mapArea.y];
            
            for (int i = 0; i < mapArea.x; i += 2)
            {
                for (int j = 0; j < mapArea.y; j += 2)
                {
                    InitializePlane(new IntVector2(i, j));
                }
            }
        }

        public IMapTileInfo InitializeEmptyTileInfo(IntVector2 index)
        {
            MapTileInfo mapTileInfo = new MapTileInfo();
            mapTileInfo.Initialize(MapTileType.Empty, index, index, null);

            return mapTileInfo;
        }

        public void InitializePlane(IntVector2 position)
        {
            MapTileInfo mapTileInfo;
            
            mapTileInfo = new MapTileInfo();
            mapTileInfo.Initialize(MapTileType.Plane, position, new IntVector2(position.x, position.y), null);
            _mapTilesInfo[position.x, position.y] = mapTileInfo;
            
            mapTileInfo = new MapTileInfo();
            mapTileInfo.Initialize(MapTileType.Plane, position, new IntVector2(position.x + 1, position.y), null);
            _mapTilesInfo[position.x + 1, position.y] = mapTileInfo;
            
            mapTileInfo = new MapTileInfo();
            mapTileInfo.Initialize(MapTileType.Plane, position, new IntVector2(position.x, position.y + 1), null);
            _mapTilesInfo[position.x, position.y + 1] = mapTileInfo;
            
            mapTileInfo = new MapTileInfo();
            mapTileInfo.Initialize(MapTileType.Plane, position, new IntVector2(position.x + 1, position.y + 1), null);
            _mapTilesInfo[position.x + 1, position.y + 1] = mapTileInfo;
        }

    }
   
}