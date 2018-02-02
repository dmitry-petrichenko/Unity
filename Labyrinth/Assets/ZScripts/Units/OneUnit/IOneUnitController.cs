using System;
using Units;
using ZScripts.Units.Rotation;
using ZScripts.Units.Settings;

namespace ZScripts.Units
{
    public interface IOneUnitController
    {
        IOneUnitMotionController MotionController { get; set; }
        IOneUnitAnimationController AnimationController { get; set; }
        IOneUnitRotationController RotationController { get; set; }
        IUnitSettings UnitSettings { get; }
        IntVector2 Position { get; }
        event Action<IntVector2> PositionChanged;
        event Action CompleteMoveTo;
        void MoveTo(IntVector2 position);
        void Wait();
    }
}