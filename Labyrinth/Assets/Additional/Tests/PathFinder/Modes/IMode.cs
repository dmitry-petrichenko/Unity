namespace Labyrinth.Additional.Tests.Modes
{
    public interface IMode
    {
        void LeftClick(IntVector2 position);
        void RightClick(IntVector2 position);
        IntVector2 Point { get; }
    }
}