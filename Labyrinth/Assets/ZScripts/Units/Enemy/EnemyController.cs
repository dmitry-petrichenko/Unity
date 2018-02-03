using Zenject;
using ZScripts.Settings;
using ZScripts.Units.Settings;

namespace ZScripts.Units.Enemy
{
    public class EnemyController : OneUnitController
    {
        private IPeacefulBehaviour _peacefulBehaviour; 
        private ISettings _settings;
        private DiContainer _container;

        [Inject]
        void Construct(
            ISettings settings,
            IPeacefulBehaviour peacefulBehaviour,
            DiContainer container
        )
        {
            _settings = settings;
            _peacefulBehaviour = peacefulBehaviour;
            _container = container;
            
            Initialize();
        }
            
        void Initialize()
        {
            UnitSettings = _container.Resolve<IUnitSettings>();
            UnitSettings.Initialize(_settings.UnitsResourcesLocation + "SpiderBlack01.json");
            base.Initialize();
        }

        public void Animate()
        {
            _peacefulBehaviour.Initialize(this);
            _peacefulBehaviour.Start();
        }
    }
}