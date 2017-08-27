using Labyrinth;

namespace Units
{
    public interface IUnitController
    {
        void MoveToPosition(IntVector2 position);
        IntVector2 Position { get; }
    }
}