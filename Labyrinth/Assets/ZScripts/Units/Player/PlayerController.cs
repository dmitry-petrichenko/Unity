using Units;
using ZScripts.Settings;
using ZScripts.Units.Rotation;

namespace ZScripts.Units.Player
{
    public class PlayerController : OneUnitController
    {
        private ISettings _settings;

        public PlayerController(
            ISettings settings, 
            IOneUnitMotionController oneUnitMotionController,
            IOneUnitAnimationController oneUnitAnimationController,
            IOneUnitRotationController oneUnitRotationController,
            MoveController moveController, 
            AttackController attackController)
            : base(
                oneUnitMotionController,
                oneUnitAnimationController,
                oneUnitRotationController,
                moveController,
                attackController
            )
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