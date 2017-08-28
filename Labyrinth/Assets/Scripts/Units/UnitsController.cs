using Labyrinth;

namespace Units
{
    public class UnitsController : IUnitsController
    {
        private PlayerController _player;

        public void Initilize()
        {
            
            
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