using Labyrinth;

namespace ZScripts.Units
{
    public interface IUnitsController
    {
        void PlayerMoveTo(IntVector2 position);
        //IUnitController Player { get; }
    }
}