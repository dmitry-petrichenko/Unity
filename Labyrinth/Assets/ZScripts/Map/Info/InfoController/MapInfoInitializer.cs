namespace ZScripts.Map.Info
{
    public class MapInfoInitializer : IMapInfoInitializer
    {
        private IMapTileInfo[,] _mapTilesInfo;

        public IMapTileInfo[,] MapTilesInfo
        {
            get { return _mapTilesInfo; }
        }
        
        public void InitializeSector(IMapTileInfo[,] mapTilesInfo)
        {
            _mapTilesInfo = mapTilesInfo;
        }

        public void CreateSector(IntVector2 startPoint, IntVector2 size)
        {
            //throw new System.NotImplementedException();
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

        public void InitializePlane(IntVector2 position)
        {
            MapTileInfo mapTileInfo;

            mapTileInfo = new MapTileInfo();
            mapTileInfo.Initialize(MapTileType.Square, position, position, null);
            _mapTilesInfo[position.x, position.y] = mapTileInfo;
            
            mapTileInfo = new MapTileInfo();
            mapTileInfo.Initialize(MapTileType.Square, position, new IntVector2(position.x + 1, position.y), null);
            _mapTilesInfo[position.x + 1, position.y] = mapTileInfo;

            mapTileInfo = new MapTileInfo();
            mapTileInfo.Initialize(MapTileType.Square, position, new IntVector2(position.x, position.y + 1), null);
            _mapTilesInfo[position.x, position.y + 1] = mapTileInfo;

            mapTileInfo = new MapTileInfo();
            mapTileInfo.Initialize(MapTileType.Square, position, new IntVector2(position.x + 1, position.y + 1), null);
            _mapTilesInfo[position.x + 1, position.y + 1] = mapTileInfo;
        }

        public IMapTileInfo CreateEmptyTileInfo(IntVector2 position)
        {
            MapTileInfo mapTileInfo = new MapTileInfo();
            mapTileInfo.Initialize(MapTileType.Empty, position, position, null);

            return mapTileInfo;
        }
    }
}