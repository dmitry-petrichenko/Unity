using ZScripts.Units.Player;

namespace ZScripts.Units
{
    public class UnitsController : IUnitsController
    {
        private PlayerController _playerController;
        
        public UnitsController(PlayerController playerController)
        {
            _playerController = playerController;
        }
        
        public void PlayerMoveTo(IntVector2 position)
        {
            _playerController.MoveTo(position);
        }
    }
}