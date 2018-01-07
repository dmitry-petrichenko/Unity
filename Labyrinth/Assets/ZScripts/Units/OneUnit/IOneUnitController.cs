using System;
using Units;

namespace ZScripts.Units
{
    public interface IOneUnitController
    {
        IOneUnitGraphicsController GraphicsController { get; set; }
        IOneUnitAnimationController AnimationController { get; set; }
        IntVector2 Position { get; }
        event Action<IntVector2> PositionChanged;
        void Initialize(IOneUnitGraphicsController GraphicsController, IOneUnitAnimationController oneUnitAnimationController);
        void MoveTo(IntVector2 position);
    }
}