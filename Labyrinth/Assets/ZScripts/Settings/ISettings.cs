using Labyrinth.Settings;
using UnityEngine;

namespace ZScripts.Settings
{
    public interface ISettings
    {
        int MapSectionSize { get; }
        int ActiveAreaSize { get; }
        IntVector2 InitializePosition { get; }
        string ResiurcesLocation { get; }
        GameInstaller.MapGraphicsList MapGraphicsList { get; }
        GameObject PlayerGraphicsObject { get; }
    }
}