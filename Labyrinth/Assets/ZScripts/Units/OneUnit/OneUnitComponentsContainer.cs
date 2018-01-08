using System;
using Units;
using UnityEditor;
using UnityEngine;
using ZScripts.Units.Rotation;

namespace ZScripts.Units
{
    public class OneUnitComponentsContainer
    {
        public event Action<IntVector2> PositionChanged;
        
        private IOneUnitMotionController _oneUnitMotionController;
        private IOneUnitAnimationController _oneUnitAnimationController;
        private IOneUnitRotationController _oneUnitRotationController;
        private IOneUnitController _oneUnitController;
        
        public OneUnitComponentsContainer(
            IOneUnitMotionController oneUnitMotionController,
            IOneUnitAnimationController oneUnitAnimationController,
            IOneUnitRotationController oneUnitRotationController,
            IOneUnitController oneUnitController)
        {
            _oneUnitRotationController = oneUnitRotationController;
            _oneUnitMotionController = oneUnitMotionController;
            _oneUnitController = oneUnitController;
            _oneUnitAnimationController = oneUnitAnimationController;
        }

        protected void Initialize(GameObject gameObject)
        {
            _oneUnitMotionController.Initialize(gameObject);
            _oneUnitAnimationController.Initialize(gameObject);
            _oneUnitRotationController.Initialize(gameObject);
            _oneUnitController.Initialize(
                _oneUnitMotionController,
                _oneUnitAnimationController,
                _oneUnitRotationController
                );
            _oneUnitController.PositionChanged += PositionChangetHandler;
        }
        
        private void PositionChangetHandler(IntVector2 position)
        {
            if (PositionChanged != null)
                PositionChanged(position);
        }
        
        public IntVector2 Position
        {
            get { return _oneUnitController.Position; }
        }
        
        public void MoveTo(IntVector2 position)
        {
            _oneUnitController.MoveTo(position);
        }
            
            
    }
}