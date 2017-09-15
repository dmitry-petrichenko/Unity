using System.Collections.Generic;

namespace Labyrinth.Map
{
    public class MapController : IMapController
    {
        private MapViewController _mapViewController;
        private MapInfoController _mapInfoController;
        private MapInfoUpdateController _mapInfoUpdateController;
        private MapViewUpdateController _mapViewUpdateController;

        public void Initialize()
        {
            InitializeComponents();

            _mapViewUpdateController = new MapViewUpdateController();
            _mapViewUpdateController.Initialize();

            _mapInfoUpdateController = new MapInfoUpdateController();
            _mapInfoUpdateController.DestroyTilesHandler += DestroyTilesHandler;
            _mapInfoUpdateController.InitializeTilesHandler += InitializeTilesHandler;
            _mapInfoUpdateController.Initialize();
        }

        private void InitializeComponents()
        {
            _mapInfoController = new MapInfoController();
            _mapInfoController.Initialize();
            MapServiceLocator.InitializeMapInfoController(_mapInfoController);

            _mapViewController = new MapViewController();
            _mapViewController.Initialize();
            MapServiceLocator.InitializeMapViewController(_mapViewController);
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