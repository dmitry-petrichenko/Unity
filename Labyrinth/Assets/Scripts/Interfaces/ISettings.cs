using Labyrinth.Settings;
using UnityEngine;

namespace Labyrinth
{
    public interface ISettings
    {
        int MapSectionSize { get; }
        int ActiveAreaSize { get; }
        IntVector2 InitializePosition { get; }
        string ResiurcesLocation { get; }
        GameObject PlayerGraphicsObject { get; }
        MapGraphicsList MapGraphicsList { get; }
    }
}