using UnityEngine;

namespace Units
{
    public interface IOneUnitAnimationController
    {
        void PlayWalkAnimation();
        void PlayAttackAnimation();
        void PlayIdleAnimation();
        void Initialize(GameObject unit);
    }
}