using System.Collections.Generic;
using NSMapTileInfo;
using UnityEngine;

namespace NSMapViewController
{
    public class MapViewController : IMapViewController
    {
        private MapInfoUpdateController _mapInfoUpdateController;

        public void Initialize()
        {
            _mapInfoUpdateController = new MapInfoUpdateController(); 
            _mapInfoUpdateController.Initialize();
            _mapInfoUpdateController.DestroyTilesHandler += DestroyTilesHandler;
            _mapInfoUpdateController.InitializeTilesHandler += InitializeTilesHandler;

        }
        
        public void UpdateCurrentPosition(IntVector2 position)
        {
            _mapInfoUpdateController.UpdateCurrentPosition(position);
        }

        private void DestroyTilesHandler(List<IMapTileInfo> tilesInfo)
        {
            Debug.Log(tilesInfo);
        }
        
        private void InitializeTilesHandler(List<IMapTileInfo> tilesInfo)
        {
            Debug.Log(tilesInfo + "create");
        }
    }
}