using System;
using ZScripts.Units.Player;

namespace ZScripts.Units
{
    public class UnitsController : IUnitsController
    {
        private PlayerController _playerController;
        
        public UnitsController(PlayerController playerController)
        {
            _playerController = playerController;
            _playerController.PositionChanged += PositionChangetHandler;
        }

        private void PositionChangetHandler(IntVector2 position)
        {
            if (PlyerPositionChanged != null)
                PlyerPositionChanged(position);
        }

        public void PlayerMoveTo(IntVector2 position)
        {
            _playerController.MoveTo(position);
        }

        public IntVector2 PlayerPosition
        {
            get { return _playerController.Position; }
        }

        public event Action<IntVector2> PlyerPositionChanged;
    }
}