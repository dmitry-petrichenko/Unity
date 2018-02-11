using Units;
using UnityEditor;
using Zenject;
using ZScripts.Units.Rotation;
using ZScripts.Units.Settings;
using ZScripts.Units.StateInfo;

namespace ZScripts.Units
{
    public class OneUnitServicesContainer : IOneUnitServicesContainer
    {
        private IOneUnitMotionController _oneUnitMotionController;
        private IOneUnitAnimationController _oneUnitAnimationController;
        private IOneUnitRotationController _oneUnitRotationController;
        private IUnitStateInfo _unitStateInfo;
        
        [Inject]
        void Construct(
            IOneUnitMotionController oneUnitMotionController,
            IOneUnitAnimationController oneUnitAnimationController,
            IOneUnitRotationController oneUnitRotationController,
            IUnitStateInfo unitStateInfo)
        {
            _oneUnitRotationController = oneUnitRotationController;
            _oneUnitMotionController = oneUnitMotionController;
            _oneUnitAnimationController = oneUnitAnimationController;
            _unitStateInfo = unitStateInfo;
        }

        public void Initialize()
        {
            _oneUnitMotionController.Initialize(UnitSettings);
            _oneUnitAnimationController.Initialize(UnitSettings);
            _oneUnitRotationController.Initialize(UnitSettings);

            MotionController = _oneUnitMotionController;
            AnimationController = _oneUnitAnimationController;
            RotationController = _oneUnitRotationController;
        }
        
        public IOneUnitMotionController MotionController { get; set; }
        public IOneUnitAnimationController AnimationController { get; set; }
        public IOneUnitRotationController RotationController { get; set; }
        public IUnitSettings UnitSettings { get; set; }
        public IUnitStateInfo UnitStateInfo { get; set; }
    }
}