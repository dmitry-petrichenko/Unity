namespace Labyrinth.Map
{
    public class MapInfoInitializer
    {
        private IMapTileInfo[,] _mapTilesInfo;

        public IMapTileInfo[,] MapTilesInfo
        {
            get { return _mapTilesInfo; }
        }

        public void Initialize(IMapTileInfo[,] mapTilesInfo)
        {
            _mapTilesInfo = mapTilesInfo;
        }

        public void Initialize(IntVector2 mapArea)
        {
            _mapTilesInfo = new IMapTileInfo[mapArea.x, mapArea.y];

            for (int i = 0; i < mapArea.x; i++)
            {
                for (int j = 0; j < mapArea.y; j++)
                {
                    InitializeSquare(new IntVector2(i, j));
                }
            }
        }

        public IMapTileInfo InitializeEmptyTileInfo(IntVector2 index)
        {
            MapTileInfo mapTileInfo = new MapTileInfo();
            mapTileInfo.Initialize(MapTileType.Empty, index, index, null);

            return mapTileInfo;
        }

        public void InitializeSquare(IntVector2 position)
        {
            MapTileInfo mapTileInfo;

            mapTileInfo = new MapTileInfo();
            mapTileInfo.Initialize(MapTileType.Square, position, position, null);
            _mapTilesInfo[position.x, position.y] = mapTileInfo;
        }

        public void InitializeCube(IntVector2 position)
        {
            MapTileInfo mapTileInfo;

            mapTileInfo = new MapTileInfo();
            mapTileInfo.Initialize(MapTileType.Cube, position, new IntVector2(position.x, position.y), null);
            _mapTilesInfo[position.x, position.y] = mapTileInfo;

            mapTileInfo = new MapTileInfo();
            mapTileInfo.Initialize(MapTileType.Cube, position, new IntVector2(position.x + 1, position.y), null);
            _mapTilesInfo[position.x + 1, position.y] = mapTileInfo;

            mapTileInfo = new MapTileInfo();
            mapTileInfo.Initialize(MapTileType.Cube, position, new IntVector2(position.x, position.y + 1), null);
            _mapTilesInfo[position.x, position.y + 1] = mapTileInfo;

            mapTileInfo = new MapTileInfo();
            mapTileInfo.Initialize(MapTileType.Cube, position, new IntVector2(position.x + 1, position.y + 1), null);
            _mapTilesInfo[position.x + 1, position.y + 1] = mapTileInfo;
        }
    }
}