﻿using System.Collections.Generic;
using ZScripts.Map.Info;

namespace ZScripts.Units.PathFinder
{
    public class Grid : IGrid
    {
        private Dictionary<IntVector2, bool> _gridValue = new Dictionary<IntVector2, bool>();
        private IMapInfoController _mapInfoController;
        private Dictionary<IntVector2, IMapTileInfo> _mapTilesInfo = new Dictionary<IntVector2, IMapTileInfo>();

        public Grid(IMapInfoController mapInfoController)
        {
            _mapInfoController = mapInfoController;
            Initialize();
        }
        
        public void Initialize()
        {
            _mapTilesInfo = _mapInfoController.MapTilesInfo;

            foreach (var info in _mapTilesInfo) 
            {
                InitializeCell(info.Key);
            }

        }

        private void InitializeCell(IntVector2 key)
        {
            _gridValue[key] = _mapInfoController.GetMapTileInfo(key).IsEmpty();
        }

        public bool GetCell(IntVector2 index)
        {
            //if (index.x >= _mapInfoCommon.MapWidth || index.y >= _mapInfoCommon.MapHeight)
                //return false;
            
            if (index.x < 0 || index.y < 0)   // TODO bug
                return false;
            
            if (_gridValue[index] != null)
            {
                return _gridValue[index];
            }

            return false;
        }
    }
}