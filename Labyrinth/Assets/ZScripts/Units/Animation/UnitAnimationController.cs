using Tests.Animation;
using UnityEngine;

namespace Units
{
    public class UnitAnimationController
    {
        private GameObject _unit;
        private IUnitScript _unitScript;
        
        public void Initialize(GameObject unit)
        {
            _unit = unit;
            //_unitScript = _unit.GetComponentInChildren<UnitScript>();
            _unitScript = _unit.GetComponentInChildren(typeof(IUnitScript)) as IUnitScript;
        }

        public void PlayIdleAnimation()
        {
            _unitScript.PlayIdleAnimation();
        }
        
        public void PlayAttackAnimation()
        {
            _unitScript.PlayAttackAnimation();
        }
        
        public void PlayWalkAnimation()
        {
            _unitScript.PlayWalkAnimation();
        }
    }
}