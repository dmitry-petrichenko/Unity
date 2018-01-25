using System.Collections.Generic;
using ZScripts.Settings;
using ZScripts.Units;

namespace ZScripts.Map.Info
{
    public partial class MapSectorController
    {
        private Dictionary<IntVector2, IMapTileInfo> _activeTiles = new Dictionary<IntVector2, IMapTileInfo>();
        
        private readonly ISettings _settings;
        private readonly IUnitsController _unitsController;
        private readonly IMapInfoStoreController _mapInfoStoreController;
        private readonly SectorLifecycleController _sectorLifecycleController;
        
        public MapSectorController(
            ISettings settings,
            IUnitsController unitsController,
            IMapInfoStoreController mapInfoStoreController,
            SectorLifecycleController sectorLifecycleController
            )
        {
            _settings = settings;
            _unitsController = unitsController;
            _mapInfoStoreController = mapInfoStoreController;
            _sectorLifecycleController = sectorLifecycleController;
            _sectorLifecycleController.Initialize(_activeTiles);

            InitializeCurrentSector();
            
            _unitsController.PlyerPositionChanged += PlayerPositionChangedHandler;
        }
        
        private void PlayerPositionChangedHandler(IntVector2 position)
        {
            UpdateCurrentSector(position);
            UpdateAdjacents(position);
            RemoveUnusedTiles();
        }
        
                
        private void RemoveUnusedTiles()
        {
            _sectorLifecycleController.UpdateSectors();
        }
        
                
        public Dictionary<IntVector2, IMapTileInfo> ActiveTiles
        {
            get { return _activeTiles;  }
        }
    }
}