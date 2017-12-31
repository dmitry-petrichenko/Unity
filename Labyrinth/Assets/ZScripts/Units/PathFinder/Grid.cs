using ZScripts.Map.Info;

namespace ZScripts.Units.PathFinder
{
    public class Grid
    {
        private bool[,] _gridValue;
        private IMapInfoController _mapInfoController;
        private IMapInfoCommon _mapInfoCommon;

        public Grid(IMapInfoController mapInfoController)
        {
            _mapInfoController = mapInfoController;
            Initialize();
        }
        
        public void Initialize()
        {
            _mapInfoCommon = _mapInfoController.MapInfoCommon;
            
            _gridValue = new bool[_mapInfoCommon.MapWidth, _mapInfoCommon.MapHeight];
            
            for (int i = 0; i < _mapInfoCommon.MapWidth; i++)
            {
                for (int j = 0; j < _mapInfoCommon.MapHeight; j++)
                {
                    InitializeCell(i, j);
                }
            }
            
        }

        private void InitializeCell(int x, int y)
        {
            _gridValue[x, y] = _mapInfoController.GetMapTileInfo(new IntVector2(x, y)).IsEmpty();
        }

        public bool GetCell(IntVector2 index)
        {
            if (index.x >= _mapInfoCommon.MapWidth || index.y >= _mapInfoCommon.MapHeight)
                return false;
            
            if (index.x < 0 || index.y < 0)   // TODO bug
                return false;
            
            if (_gridValue[index.x, index.y] != null)
            {
                return _gridValue[index.x, index.y];
            }

            return false;
        }
    }
}