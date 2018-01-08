using System;
using Units;
using ZScripts.Units.Rotation;

namespace ZScripts.Units
{
    public interface IOneUnitController
    {
        IOneUnitMotionController MotionController { get; set; }
        IOneUnitAnimationController AnimationController { get; set; }
        IOneUnitRotationController RotationController { get; set; }
        IntVector2 Position { get; }
        event Action<IntVector2> PositionChanged;
        void Initialize(
            IOneUnitMotionController GraphicsController, 
            IOneUnitAnimationController oneUnitAnimationController,
            IOneUnitRotationController oneUnitRotationController
            );
        void MoveTo(IntVector2 position);
    }
}