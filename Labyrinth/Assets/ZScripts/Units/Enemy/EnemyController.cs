using Units;
using ZScripts.Settings;
using ZScripts.Units.Rotation;
using ZScripts.Units.Settings;

namespace ZScripts.Units.Enemy
{
    public class EnemyController : OneUnitController
    {
        private IPeacefulBehaviour _peacefulBehaviour; 
        private ISettings _settings;
        
        public EnemyController(
            ISettings settings,
            IOneUnitMotionController oneUnitMotionController,
            IOneUnitAnimationController oneUnitAnimationController,
            IOneUnitRotationController oneUnitRotationController,
            MoveController moveController, 
            AttackController attackController,
            IPeacefulBehaviour peacefulBehaviour
            )
            : base(
                oneUnitMotionController,
                oneUnitAnimationController,
                oneUnitRotationController,
                moveController,
                attackController
            )
        {
            _settings = settings;
            _peacefulBehaviour = peacefulBehaviour;
            Initialize();
        }
        
        private void Initialize()
        {
            base.Initialize(_settings.PlayerGraphicsObject);
            UnitSettings = new UnitSettings(Settings.UnitSettings.UnitType.Player);
            
            _peacefulBehaviour.Initialize(this);
            _peacefulBehaviour.Start();
        }
    }
}