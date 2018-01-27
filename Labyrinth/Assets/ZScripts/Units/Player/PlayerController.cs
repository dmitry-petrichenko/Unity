using System;
using System.Diagnostics;
using Units;
using ZScripts.Settings;
using ZScripts.Units.Rotation;

namespace ZScripts.Units.Player
{
    public class PlayerController : OneUnitController, IPlayerController
    {
        private ISettings _settings;
        private IGameEvents _gameEvents;

        public PlayerController(
            ISettings settings, 
            IOneUnitMotionController oneUnitMotionController,
            IOneUnitAnimationController oneUnitAnimationController,
            IOneUnitRotationController oneUnitRotationController,
            MoveController moveController, 
            AttackController attackController,
            IGameEvents gameEvents)
            : base(
                oneUnitMotionController,
                oneUnitAnimationController,
                oneUnitRotationController,
                moveController,
                attackController
            )
        {
            _settings = settings;
            _gameEvents = gameEvents;
            Initialize();
        }

        protected override void UpdatePosition()
        {
            base.UpdatePosition();
            _gameEvents.TriggerPlayerPositionChanged(Position);
        }
        
        private void Initialize()
        {
            base.Initialize(_settings.PlayerGraphicsObject);
        }

        public void Attack(IntVector2 position)
        {
        }
    }
}