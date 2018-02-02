using Zenject;
using ZScripts.Settings;
using ZScripts.Units.Settings;

namespace ZScripts.Units.Player
{
    public class PlayerController : OneUnitController, IPlayerController
    {
        private ISettings _settings;
        private IGameEvents _gameEvents;

        protected override void UpdatePosition()
        {
            base.UpdatePosition();
            _gameEvents.TriggerPlayerPositionChanged(Position);
        }

        [Inject]
        void Construct(
            ISettings settings,
            IGameEvents gameEvents)
        {
            _settings = settings;
            _gameEvents = gameEvents;
            
            Initialize();
        }
        
        private void Initialize()
        {
            UnitSettings = new UnitSettings(Settings.UnitSettings.UnitType.Player, 
                _settings.PlayerGraphicsObject);
            base.Initialize();

            CompleteMoveTo += Wait;
            SetOnPosition(new IntVector2(0, 0));
        }

        public void Attack(IntVector2 position)
        {
        }
    }
}