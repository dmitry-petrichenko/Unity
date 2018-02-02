using Units;
using ZScripts.Units.Rotation;
using ZScripts.Units.Settings;

namespace ZScripts.Units
{
    public interface IOneUnitServicesContainer
    {
        IOneUnitMotionController MotionController { get; set; }
        IOneUnitAnimationController AnimationController { get; set; }
        IOneUnitRotationController RotationController { get; set; }
        IUnitSettings UnitSettings { get; }
    }
}