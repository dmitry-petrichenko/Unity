namespace Labyrinth.Settings
{
    public class SettingsList : ISettings
    {
        public int MapSectionSize { get; private set; }
        public int ActiveAreaSize { get; private set; }
        public IntVector2 InitializePosition { get; private set; }

        public SettingsList()
        {

        }

        public void Initialize()
        {
            MapSectionSize = 2;
            ActiveAreaSize = 16;
            InitializePosition = new IntVector2(0, 0);
        }
    }
}