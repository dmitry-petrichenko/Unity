namespace Labyrinth
{
    public interface ISettings
    {
        int MapSectionSize { get; }
        int ActiveAreaSize { get; }
        IntVector2 InitializePosition { get; }
    }
}