using UnityEngine;
using ZScripts;
using ZScripts.Settings;

namespace Additional.Tests.SectorLoader
{
    public class ExtraSettings : ISettings
    {
        private ISettings _settings;
        public ExtraSettings(GameInstaller.MapGraphicsList mapGraphicsList)
        {
            _settings = new SettingsList(mapGraphicsList);
        }

        public int MapSectionSize { get { return _settings.MapSectionSize; }}
        public int ActiveAreaSize { get { return 7; }}
        public IntVector2 InitializePosition { get { return _settings.InitializePosition; }}
        public string MapsResourcesLocation { get { return _settings.MapsResourcesLocation; }}
        public string UnitsResourcesLocation { get; private set; }
        public GameInstaller.MapGraphicsList MapGraphicsList { get { return _settings.MapGraphicsList; }}
        public GameObject PlayerGraphicsObject
        {
            get { return null; }
        }
        public GameObject EnemyGraphicsObject { get; private set; }
    }
}