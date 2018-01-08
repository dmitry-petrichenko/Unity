using Units;
using ZScripts.Settings;
using ZScripts.Units.Rotation;

namespace ZScripts.Units.Player
{
    public class PlayerController : OneUnitComponentsContainer
    {
        private ISettings _settings;

        public PlayerController(
            ISettings settings, 
            IOneUnitMotionController oneUnitMotionController,
            IOneUnitAnimationController oneUnitAnimationController,
            IOneUnitRotationController oneUnitRotationController,
            IOneUnitController oneUnitController)
            : base(
                oneUnitMotionController,
                oneUnitAnimationController,
                oneUnitRotationController,
                oneUnitController)
        {
            _settings = settings;
            Initialize();
        }

        public void Initialize()
        {
            base.Initialize(_settings.PlayerGraphicsObject);
        }

        public void Attack(IntVector2 position)
        {
        }
    }
}