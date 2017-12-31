using ZScripts.Map;
using ZScripts.Units;

namespace ZScripts
{
    public class ActiveMapLocationController
    {
        private IMapController _mapController;
        private IUnitsController _unitsController;

        public ActiveMapLocationController(IMapController mapController,
            IUnitsController unitsController)
        {
            _mapController = mapController;
            _unitsController = unitsController;

            Initialize();
        }

        public void Initialize()
        {
            _unitsController.PlyerPositionChanged += PlayerPositionChanged;
        }

        private void PlayerPositionChanged(IntVector2 position)
        {
            _mapController.UpdateCurrentPosition(position);
        }
    }
}