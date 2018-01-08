using UnityEngine;

namespace ZScripts.Units.Rotation
{
    public interface IOneUnitRotationController
    {
        void Initialize(GameObject unit);
        void Rotate(IntVector2 point1, IntVector2 point2);
    }
}