using UnityEngine;

namespace Units
{
    public class UnitAnimationController
    {
        private GameObject _unit;
        private UnitScript _unitScript;
        
        public void Initialize(GameObject unit)
        {
            _unit = unit;
            _unitScript = _unit.GetComponentInChildren<UnitScript>();
        }

        public void PlayIdleAnimation()
        {
            _unitScript.playIdleAnimation();
        }
        
        public void PlayAttackAnimation()
        {
            _unitScript.playAttackAnimation();
        }
        
        public void PlayWalkAnimation()
        {
            _unitScript.playWalkingAnimation();
        }
    }
}