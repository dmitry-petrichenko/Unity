using UnityEngine;

namespace ZScripts.Settings
{
    public class SettingsList : ISettings
    {
        
        public int MapSectionSize { get; private set; }
        public int ActiveAreaSize { get; protected set; }
        public IntVector2 InitializePosition { get; private set; }
        public string MapsResourcesLocation { get; private set; }
        public string UnitsResourcesLocation { get; private set; }
        public GameInstaller.MapGraphicsList MapGraphicsList { get; private set; }
        private GameObject _mainScene;

        private const string TEST_MAP_PATH = "TestMap_02/";

        public SettingsList(GameInstaller.MapGraphicsList mapGraphicsList)
        {
            _mainScene = MainScene.instance;
            MapGraphicsList = mapGraphicsList;
            Initialize();
        }

        public void Initialize()
        {
            MapSectionSize = 2;
            ActiveAreaSize = 14;
            InitializePosition = new IntVector2(0, 0);
            MapsResourcesLocation = Application.dataPath + "/Resources/Maps/" + TEST_MAP_PATH;
            UnitsResourcesLocation = Application.dataPath + "/Resources/Units/Settings/";
        }
        
    }
}