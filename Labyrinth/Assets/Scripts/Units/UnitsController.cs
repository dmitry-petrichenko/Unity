using Labyrinth;
using Labyrinth.Units;
using Units.PathFinder;

namespace Units
{
    public class UnitsController : IUnitsController
    {
        private PlayerController _player;
        private PathFinderController _pathFinderController;

        public void Initilize()
        {
            _pathFinderController = new PathFinderController();
            _pathFinderController.Initialize();
            UnitsServiceLocator.InitializePathFinder(_pathFinderController);
            
            _player = new PlayerController();
            _player.Initialize();
        }

        public void PlayerMoveTo(IntVector2 position)
        {
            _player.MoveTo(position);
        }

        public IUnitController Player
        {
            get { return _player; }
        }
    }
}