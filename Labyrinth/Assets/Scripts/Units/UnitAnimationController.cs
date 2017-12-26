using UnityEngine;

namespace Units
{
    public class UnitAnimationController
    {
        private GameObject _unit;
        
        public void Initialize(GameObject unit)
        {
            _unit = unit;
            //_unit.GetComponentInChildren<UnitScript>();
        }
    }
}