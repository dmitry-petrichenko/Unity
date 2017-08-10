using Labyrinth;

namespace Units
{
    public class UnitsController : IUnitsController
    {
        private PlayerController _player;

        public void Initializr()
        {
            _player = new PlayerController();
            _player.Initialize(); 
        }

        public void PlayerMoveTo(IntVector2 position)
        {
            _player.MoveTo(position);
        }
    }
}