using Labyrinth;
using UnityEngine;

namespace Units
{
    public class PlayerController : Unit
    {
        private ISettings _settings;
        private UnitController _unitController;
        private UnitGraphicsController _unitGraphicsController;
        
        public void Initialize()
        {
            _settings = ServiceLocator.GetSettings();
            
            _unitGraphicsController = new UnitGraphicsController();
            _unitGraphicsController.Initialize(_settings.PlayerGraphicsObject);
            
            _unitController = new UnitController();
            _unitController.Initialize(_unitGraphicsController);
        }

        public void MoveTo(IntVector2 position)
        {
            _unitController.MoveTo(position);
        }

        public void Attack(IntVector2 position)
        {
            
        }
    }
}