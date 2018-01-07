using System;
using Units;
using UnityEditor;
using UnityEngine;

namespace ZScripts.Units
{
    public class OneUnitComponentsContainer
    {
        public event Action<IntVector2> PositionChanged;
        
        private IOneUnitGraphicsController _oneUnitGraphicsController;
        private IOneUnitAnimationController _oneUnitAnimationController;
        private IOneUnitController _oneUnitController;
        
        public OneUnitComponentsContainer(
            IOneUnitGraphicsController oneUnitGraphicsController,
            IOneUnitAnimationController oneUnitAnimationController,
            IOneUnitController oneUnitController)
        {
            _oneUnitGraphicsController = oneUnitGraphicsController;
            _oneUnitController = oneUnitController;
            _oneUnitAnimationController = oneUnitAnimationController;
        }

        protected void initialize(GameObject gameObject)
        {
            _oneUnitGraphicsController.Initialize(gameObject);
            _oneUnitAnimationController.Initialize(gameObject);
            _oneUnitController.Initialize(
                _oneUnitGraphicsController,
                _oneUnitAnimationController
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