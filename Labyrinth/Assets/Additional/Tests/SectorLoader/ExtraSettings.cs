using ZScripts;
using ZScripts.Settings;

namespace Additional.Tests.SectorLoader
{
    public class ExtraSettings : SettingsList
    {
        public ExtraSettings(GameInstaller.MapGraphicsList mapGraphicsList) : base(mapGraphicsList)
        {
            ActiveAreaSize = 2;
        }
    }
}