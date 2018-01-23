using ZScripts.Settings;
using ZScripts.Units;

namespace ZScripts.Map.Info
{
    public partial class MapSectorController
    {
        private readonly ISettings _settings;
        private readonly IUnitsController _unitsController;
        private readonly IMapInfoStoreController _mapInfoStoreController;
        
        public MapSectorController(
            ISettings settings,
            IUnitsController unitsController,
            IMapInfoStoreController mapInfoStoreController
            )
        {
            _settings = settings;
            _unitsController = unitsController;
            _mapInfoStoreController = mapInfoStoreController;

            InitializeCurrentSector();
            
            _unitsController.PlyerPositionChanged += PlayerPositionChangedHandler;
        }
        
        private void PlayerPositionChangedHandler(IntVector2 position)
        {
            UpdateCurrentSector(position);
            UpdateAdjacents(position);
            RemoveUnusedTiles();
        }
    }
}