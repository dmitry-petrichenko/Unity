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
        public string ResiurcesLocation { get { return _settings.ResiurcesLocation; }}
        public GameInstaller.MapGraphicsList MapGraphicsList { get { return _settings.MapGraphicsList; }}
        public GameObject PlayerGraphicsObject { get { return _settings.PlayerGraphicsObject; }}
    }
}