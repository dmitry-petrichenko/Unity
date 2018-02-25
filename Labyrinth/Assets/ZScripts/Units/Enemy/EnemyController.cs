using Zenject;
using ZScripts.Settings;
using ZScripts.Units.Settings;

namespace ZScripts.Units.Enemy
{
    public class EnemyController : OneUnitController
    {
        private IPeacefulBehaviour _peacefulBehaviour; 
        private IAgressiveBehaviour _agressiveBehaviour; 
        private IUnitSettings _unitSettings; 
        private ISettings _settings;
        private DiContainer _container;

        [Inject]
        void Construct(
            ISettings settings,
            IUnitSettings unitSettings,
            IPeacefulBehaviour peacefulBehaviour,
            IAgressiveBehaviour agressiveBehaviour,
            DiContainer container
        )
        {
            _settings = settings;
            _unitSettings = unitSettings;
            _peacefulBehaviour = peacefulBehaviour;
            _agressiveBehaviour = agressiveBehaviour;
            _container = container;
            
            Initialize();
        }
            
        void Initialize()
        {
            UnitSettings = _unitSettings;
            UnitSettings.Initialize(_settings.UnitsResourcesLocation + "SpiderBlack01.json");
            base.Initialize();
            
            _peacefulBehaviour.Initialize(this);
            _agressiveBehaviour.Initialize(this);
        }

        public void Animate()
        {
            _peacefulBehaviour.Initialize(this);
            _peacefulBehaviour.Start();
        }

        public void Attack(IOneUnitController oneUnitController)
        {
            _agressiveBehaviour.Start(oneUnitController);
        }
    }
}