using Labyrinth;

namespace Units
{
    public class PlayerController : UnitController
    {
        private ISettings _settings;
        private UnitGraphicsController _unitGraphicsController;

        public void Initialize()
        {
            _settings = ServiceLocator.GetSettings();

            _unitGraphicsController = new UnitGraphicsController();
            _unitGraphicsController.Initialize(_settings.PlayerGraphicsObject);

            base.Initialize(_unitGraphicsController);
        }

        public void Attack(IntVector2 position)
        {
        }
    }
}