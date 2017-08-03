using System;
using System.Collections.Generic;
using NSMapInfoController;
using NSMapTileInfo;

namespace NSMapViewController
{
    public class MapInfoUpdateController 
    {
        public delegate void InfoUpdateHandler(List<IMapTileInfo> tiles);

        public event InfoUpdateHandler DestroyTilesHandler;
        public event InfoUpdateHandler InitializeTilesHandler;

        private IMapInfoController _mapInfoController;
        private IntVector2 _currentPosition;
        private int _mapSectionSize = 4;
        private int _halfActiveAreaX = 8;
        private int _halfActiveAreaY = 8;
        private int _updateTime;
        private Dictionary<IntVector2, MapTileInfoContainer> _mapTileInfoContainers;
        private List<IMapTileInfo> _tilesInfoToDestroy;
        private List<IMapTileInfo> _tilesInfoToInitialize;
        
        public MapInfoUpdateController()
        {
            
        }

        public void Initialize()
        {
            _mapInfoController = ServiceLocator.GetMapInfoController();
            _mapTileInfoContainers = new Dictionary<IntVector2, MapTileInfoContainer>();
        }

        public void UpdateCurrentPosition(IntVector2 currentPosition)
        {
            UpdateTilesInfoTime(currentPosition);
            ResetTiles();
        }

        private void ResetTiles()
        {
            _tilesInfoToDestroy = new List<IMapTileInfo>();
            Dictionary<IntVector2, MapTileInfoContainer> _newMapTileInfoContainers = new Dictionary<IntVector2, MapTileInfoContainer>();
            foreach (MapTileInfoContainer tileContainer in _mapTileInfoContainers.Values)
            {
                if (tileContainer.InitializeTime != _updateTime)
                {
                    _tilesInfoToDestroy.Add(tileContainer.MapTileInfo);
                }
                else
                {
                    _newMapTileInfoContainers.Add(tileContainer.MapTileInfo.Index, tileContainer);
                }
            }

            DestroyTilesHandler(_tilesInfoToDestroy);
        }

        private void UpdateTilesInfoTime(IntVector2 currentPosition)
        {
            _tilesInfoToInitialize = new List<IMapTileInfo>();
            
            int positionDisplacementX = currentPosition.x - _currentPosition.x;
            int positionDisplacementY = currentPosition.y - _currentPosition.y;

            IntVector2 tileIndex;
            IMapTileInfo mapTileInfo;
            MapTileInfoContainer mapTileInfoContainer;
            
            _updateTime = new DateTime().Millisecond;
            
            if (Math.Abs(positionDisplacementX) >= _mapSectionSize ||
                Math.Abs(positionDisplacementY) >= _mapSectionSize)
            {
                for (int x = -_halfActiveAreaX; x < _halfActiveAreaX; x++)
                {
                    for (int y = -_halfActiveAreaY; y < _halfActiveAreaY; y++)
                    {
                        tileIndex = new IntVector2(x, y);
                        if (!_mapTileInfoContainers.ContainsKey(tileIndex))
                        {
                            mapTileInfo = _mapInfoController.GetMapTileInfo(tileIndex);
                            mapTileInfoContainer = new MapTileInfoContainer(mapTileInfo, _updateTime);
                            _mapTileInfoContainers.Add(tileIndex, mapTileInfoContainer);
                            _tilesInfoToInitialize.Add(mapTileInfo);
                        }
                        else
                        {
                            _mapTileInfoContainers[tileIndex].InitializeTime = _updateTime;
                        }
                    }
                }
            }

            _currentPosition = currentPosition;

            InitializeTilesHandler(_tilesInfoToInitialize);
        }
    }

    class MapTileInfoContainer
    {
        public IMapTileInfo MapTileInfo;
        public float InitializeTime;

        public MapTileInfoContainer(IMapTileInfo MapTileInfo, float InitializeTime)
        {
            this.MapTileInfo = MapTileInfo;
            this.InitializeTime = InitializeTime;
        }
    }
    
}