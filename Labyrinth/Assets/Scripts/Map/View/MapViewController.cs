using System.Collections.Generic;
using Labyrinth;

namespace Map
{
    public class MapViewController : IMapViewController
    {
        private MapInfoUpdateController _mapInfoUpdateController;
        private MapViewUpdateController _mapViewUpdateController;


        public void Initialize()
        {
            _mapViewUpdateController = new MapViewUpdateController();
            _mapViewUpdateController.Initialize();

            _mapInfoUpdateController = new MapInfoUpdateController();
            _mapInfoUpdateController.DestroyTilesHandler += DestroyTilesHandler;
            _mapInfoUpdateController.InitializeTilesHandler += InitializeTilesHandler;
            _mapInfoUpdateController.Initialize();
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