using Units;
using ZScripts.Settings;

namespace ZScripts.Units.Player
{
    public class PlayerController : OneUnitComponentsContainer
    {
        private ISettings _settings;

        public PlayerController(
            ISettings settings, 
            IOneUnitGraphicsController oneUnitGraphicsController,
            IOneUnitAnimationController oneUnitAnimationController,
            IOneUnitController oneUnitController)
            : base(
                oneUnitGraphicsController,
                oneUnitAnimationController,
                oneUnitController)
        {
            _settings = settings;
            Initialize();
        }

        public void Initialize()
        {
            base.initialize(_settings.PlayerGraphicsObject);

        }

        public void Attack(IntVector2 position)
        {
        }
       
    }
}