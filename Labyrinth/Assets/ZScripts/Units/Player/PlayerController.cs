using System;
using ZScripts.Settings;

namespace ZScripts.Units.Player
{
    public class PlayerController
    {
        private ISettings _settings;
        private IOneUnitGraphicsController _oneUnitGraphicsController;
        private IOneUnitController _oneUnitController;
        
        public event Action<IntVector2> PositionChanged;

        public PlayerController(
            ISettings settings, 
            IOneUnitGraphicsController oneUnitGraphicsController,
            IOneUnitController oneUnitController)
        {
            _settings = settings;
            _oneUnitGraphicsController = oneUnitGraphicsController;
            _oneUnitController = oneUnitController;
            Initialize();
        }

        public void Initialize()
        {
            _oneUnitGraphicsController.Initialize(_settings.PlayerGraphicsObject);
            _oneUnitController.Initialize(_oneUnitGraphicsController);
            _oneUnitController.PositionChanged += PositionChangetHandler;
        }
        
        private void PositionChangetHandler(IntVector2 position)
        {
            if (PositionChanged != null)
                PositionChanged(position);
        }
        
        public IntVector2 Position
        {
            get { return _oneUnitController.Position; }
        }

        public void Attack(IntVector2 position)
        {
        }
        
        public void MoveTo(IntVector2 position)
        {
            _oneUnitController.MoveTo(position);
        }
    }
}