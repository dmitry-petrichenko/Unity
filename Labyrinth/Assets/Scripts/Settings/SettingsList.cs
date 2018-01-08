using UnityEngine;

namespace Labyrinth.Settings
{
    public class SettingsList : ISettings
    {
        public int MapSectionSize { get; private set; }
        public int ActiveAreaSize { get; private set; }
        public IntVector2 InitializePosition { get; private set; }
        public string ResiurcesLocation { get; private set; }
        public GameObject PlayerGraphicsObject { get; private set; }
        public MapGraphicsList MapGraphicsList { get; private set; }

        public SettingsList()
        {
        }

        public void Initialize(MapGraphicsList mapGraphicsList, GameObject playerObject)
        {
            MapGraphicsList = mapGraphicsList;
            PlayerGraphicsObject = playerObject;
            Initialize();
        }

        public void Initialize()
        {
            MapSectionSize = 2;
            ActiveAreaSize = 16;
            InitializePosition = new IntVector2(0, 0);
            ResiurcesLocation = Application.dataPath + "/Resources/Maps";
        }
    }
}