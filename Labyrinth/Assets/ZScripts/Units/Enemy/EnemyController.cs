using Zenject;
using ZScripts.Settings;
using ZScripts.Units.Settings;

namespace ZScripts.Units.Enemy
{
    public class EnemyController : OneUnitController
    {
        private IPeacefulBehaviour _peacefulBehaviour; 
        private ISettings _settings;

        [Inject]
        void Construct(
            ISettings settings,
            IPeacefulBehaviour peacefulBehaviour
        )
        {
            _settings = settings;
            _peacefulBehaviour = peacefulBehaviour;
            
            Initialize();
        }
            
        void Initialize()
        {
            UnitSettings = new UnitSettings(Settings.UnitSettings.UnitType.Spider, 
                _settings.EnemyGraphicsObject);
            base.Initialize();
        }

        public void Animate()
        {
            _peacefulBehaviour.Initialize(this);
            _peacefulBehaviour.Start();
        }
    }
}