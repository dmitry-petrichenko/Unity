using System;
using ZScripts.Units.Player;

namespace ZScripts.Units
{
    public class UnitsController : IUnitsController
    {
        private IPlayerController _playerController;
        
        public UnitsController(IPlayerController playerController)
        {
            _playerController = playerController;
        }
    }
}