using Labyrinth;
using UnityEngine;

namespace Units
{
    public interface IUnitsController
    {
        void PlayerMoveTo(IntVector2 position);
    }
}