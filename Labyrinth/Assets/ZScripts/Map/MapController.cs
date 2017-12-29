using System.Collections.Generic;
using ZScripts.Map.Info;
using ZScripts.Map.View;
using MapInfoUpdateController = ZScripts.Map.Controllers.MapInfoUpdateController;
using MapViewUpdateController = ZScripts.Map.Controllers.MapViewUpdateController;

namespace ZScripts.Map
{
    public class MapController : IMapController
    {
        private MapViewController _mapViewController;
        private MapInfoController _mapInfoController;
        private MapInfoUpdateController _mapInfoUpdateController;
        private MapViewUpdateController _mapViewUpdateController;

        public MapController(
            MapInfoController mapInfoController, 
            MapViewController mapViewController,
            MapViewUpdateController mapViewUpdateController,
            MapInfoUpdateController mapInfoUpdateController)
        
        {
            _mapInfoController = mapInfoController;
            _mapViewController = mapViewController;
            _mapViewUpdateController = mapViewUpdateController;
            _mapInfoUpdateController = mapInfoUpdateController;

            Initialize();
        }

        public void Initialize()
        {
            _mapInfoUpdateController.DestroyTilesHandler += DestroyTilesHandler;
            _mapInfoUpdateController.InitializeTilesHandler += InitializeTilesHandler;
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