﻿using UnityEngine;

namespace ZScripts.Settings
{
    public class SettingsList : ISettings
    {
        public int MapSectionSize { get; private set; }
        public int ActiveAreaSize { get; private set; }
        public IntVector2 InitializePosition { get; private set; }
        public string ResiurcesLocation { get; private set; }
        public GameInstaller.MapGraphicsList MapGraphicsList { get; private set; }

        public SettingsList(GameInstaller.MapGraphicsList mapGraphicsList)
        {
            MapGraphicsList = mapGraphicsList;
            Initialize();
        }

        public void Initialize()
        {
            MapSectionSize = 2;
            ActiveAreaSize = 16;
            InitializePosition = new IntVector2(0, 0);
            ResiurcesLocation = Application.dataPath + "/Resources";
        }
    }
}