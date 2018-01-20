namespace ZScripts.Units.PathFinder
{
    public interface IGrid
    {
        void Initialize();
        bool GetCell(IntVector2 index);
    }
}