using System.Collections.Generic;
using ZScripts;
using ZScripts.Map.Info;
using ZScripts.Map.View;
using ZScripts.Settings;

namespace Additional.Tests.SectorLoader
{
    public class MapViewController
    {
        private GraphicsController _sectorGraphicsController;
        private List<IntVector2> _initializedIndexes;
        private MapSectorController _mapSectorController;
        private ISettings _settings;

        public void Initialize(MapSectorController mapSectorController)
        {
            _sectorGraphicsController = MapServiceLocator.GetSectorGraphicsController();
            _mapSectorController = mapSectorController;
            _settings = ServiceLocator.GetSettings();
                
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
            int xWidth = _settings.ActiveAreaSize / 2;
            int xHeight = _settings.ActiveAreaSize / 2;
            
            for (int i = -xWidth; i < xWidth; i++)
            {
                   for (int j = -xHeight; j < xHeight; j++)
                   {
                       InitializeVisibleTile(new IntVector2(position.x + i, position.y + j));        
                   }
            }
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