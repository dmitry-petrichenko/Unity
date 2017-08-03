using System.Collections.Generic;
using NSMapTileInfo;
using UnityEngine;

namespace NSMapViewController
{
    public class MapViewController : IMapViewController
    {
        private MapInfoUpdateController _mapInfoUpdateController;
        private MapViewUpdateController _mapViewUpdateController;

        public void Initialize()
        {
            _mapInfoUpdateController = new MapInfoUpdateController(); 
            _mapInfoUpdateController.Initialize();
            _mapInfoUpdateController.DestroyTilesHandler += DestroyTilesHandler;
            _mapInfoUpdateController.InitializeTilesHandler += InitializeTilesHandler;
            
            
            _mapViewUpdateController = new MapViewUpdateController();
            _mapViewUpdateController.Initialize();
            

        }
        
        public void UpdateCurrentPosition(IntVector2 position)
        {
            _mapInfoUpdateController.UpdateCurrentPosition(position);
        }

        private void DestroyTilesHandler(List<IMapTileInfo> tilesInfo)
        {
            _mapViewUpdateController.DestroyTiles(tilesInfo);
        }
        
        private void InitializeTilesHandler(List<IMapTileInfo> tilesInfo)
        {
            _mapViewUpdateController.InitializeTiles(tilesInfo);
        }
    }
}