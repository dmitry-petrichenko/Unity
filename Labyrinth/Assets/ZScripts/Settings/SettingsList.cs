using UnityEngine;

namespace ZScripts.Settings
{
    public class SettingsList : ISettings
    {
        
        public int MapSectionSize { get; private set; }
        public int ActiveAreaSize { get; private set; }
        public IntVector2 InitializePosition { get; private set; }
        public string ResiurcesLocation { get; private set; }
        public GameInstaller.MapGraphicsList MapGraphicsList { get; private set; }
        public  GameObject PlayerGraphicsObject { get; private set; }
        private GameObject _mainScene;

        public SettingsList(GameInstaller.MapGraphicsList mapGraphicsList)
        {
            _mainScene = MainScene.instance;
            MapGraphicsList = mapGraphicsList;
            Initialize();
        }

        public void Initialize()
        {
            InitializePlayerGraphicsObject();
            MapSectionSize = 2;
            ActiveAreaSize = 16;
            InitializePosition = new IntVector2(0, 0);
            ResiurcesLocation = Application.dataPath + "/Resources";
        }

        private void InitializePlayerGraphicsObject()
        {
            PlayerGraphicsObject = Object.Instantiate(MapGraphicsList.Player, new Vector3(3, 0.0f, 3), Quaternion.identity,
                _mainScene.transform);
        }
    }
}