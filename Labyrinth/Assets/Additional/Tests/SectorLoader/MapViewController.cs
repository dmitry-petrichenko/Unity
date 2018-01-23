using System.Collections.Generic;
using ZScripts;
using ZScripts.Map.Info;
using ZScripts.Map.View;

namespace Additional.Tests.SectorLoader
{
    public class MapViewController
    {
        private GraphicsController _sectorGraphicsController;
        private List<IntVector2> _initializedIndexes;
        private MapSectorController _mapSectorController;

        public void Initialize(MapSectorController mapSectorController)
        {
            _sectorGraphicsController = MapServiceLocator.GetSectorGraphicsController();
            _mapSectorController = mapSectorController;
            
            UpdateTiles();
        }

        public void UpdateTiles()
        {
            _sectorGraphicsController.ClearGraphics();
            
            foreach (var info in _mapSectorController.ActiveTiles) 
            {
                InitializeTile(info.Value);
            }
            
        }

        private void InitializeVisibleTile(IntVector2 position)
        {
            if (_mapSectorController.ActiveTiles.ContainsKey(position))
            {
                _sectorGraphicsController.InitializeVisible(position);
            }
        }

        public void SetVisibleTiles(IntVector2 position)
        {
            InitializeVisibleTile(position);
            InitializeVisibleTile(new IntVector2(position.x + 1, position.y));
            InitializeVisibleTile(new IntVector2(position.x, position.y + 1));
            InitializeVisibleTile(new IntVector2(position.x + 1, position.y + 1));
            InitializeVisibleTile(new IntVector2(position.x, position.y - 1));
            InitializeVisibleTile(new IntVector2(position.x - 1, position.y));
            InitializeVisibleTile(new IntVector2(position.x - 1, position.y + 1));
            InitializeVisibleTile(new IntVector2(position.x - 1, position.y - 1));
            InitializeVisibleTile(new IntVector2(position.x + 1, position.y - 1));
        }

        private void InitializeTile(IMapTileInfo tileInfo)
        {
            IntVector2 position = new IntVector2(tileInfo.Index.x, tileInfo.Index.y);
            switch (tileInfo.Type)
            {
                case MapTileType.Cube:
                {
                    _sectorGraphicsController.InitializeCube(position);
                    break;
                }
                case MapTileType.Square:
                {
                    _sectorGraphicsController.InitializeSquare(position);
                    break;
                }
                case MapTileType.Empty:
                {
                    _sectorGraphicsController.InitializeEmpty(position);
                    break;
                }
            }
        }
    }
}