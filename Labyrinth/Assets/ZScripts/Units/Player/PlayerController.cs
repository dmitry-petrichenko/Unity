using Zenject;
using ZScripts.Settings;
using ZScripts.Units.Settings;

namespace ZScripts.Units.Player
{
    public class PlayerController : OneUnitController, IPlayerController
    {
        private ISettings _settings;
        private IGameEvents _gameEvents;
        private DiContainer _container;

        protected override void UpdatePosition()
        {
            base.UpdatePosition();
            _gameEvents.TriggerPlayerPositionChanged(Position);
        }

        [Inject]
        void Construct(
            ISettings settings,
            IGameEvents gameEvents,
            DiContainer container)
        {
            _settings = settings;
            _gameEvents = gameEvents;
            _container = container;
            
            Initialize();
        }
        
        private void Initialize()
        {
            UnitSettings = _container.Resolve<IUnitSettings>();
            UnitSettings.Initialize(_settings.UnitsResourcesLocation + "RedMage.json");
            base.Initialize();

            CompleteMoveTo += Wait;
            SetOnPosition(new IntVector2(1, 2));
        }

        public void Attack(IntVector2 position)
        {
        }
    }
}