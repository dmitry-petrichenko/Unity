using System.Collections.Generic;
using UnityEngine;

namespace ZScripts.Map.Info
{
    public partial class MapSectorController
    {     
        private ISectorInfo _currentSector;
        private Dictionary<IntVector2, ISectorInfo> _loadedSections = new Dictionary<IntVector2, ISectorInfo>();
        private Dictionary<IntVector2, IMapTileInfo> _activeTiles = new Dictionary<IntVector2, IMapTileInfo>();
        
        private void InitializeCurrentSector()
        {
            IntVector2 index = new IntVector2(0, 0);
            _currentSector = _mapInfoStoreController.UploadSectorInfo(index);
            _loadedSections[_currentSector.index] = _currentSector;
            UploadSector(index);
            IntVector2 iv2 = GetPositionVisibleProgression(new IntVector2(6, 3), _currentSector);
        }

        private void UploadSector(IntVector2 index)
        {
            Dictionary<IntVector2, IMapTileInfo> uploadedTiles;
                       
            uploadedTiles = _mapInfoStoreController.UploadSectorData(index);

            AddTiles(uploadedTiles);
        }

        private void AddTiles(Dictionary<IntVector2, IMapTileInfo> uploadedTiles)
        {
            foreach (var info in uploadedTiles)
            {
                _activeTiles[info.Key] = info.Value;
            }
        }

        private void UpdateCurrentSector(IntVector2 position)
        {
            _currentSector =  GetSectorOfPosition(position, _currentSector);
        }

        private ISectorInfo GetSectorOfPosition(IntVector2 position, ISectorInfo sectorInfo)
        {
            if (IsPositionInSector(sectorInfo, position))
            {
                return sectorInfo;
            }
            else
            {
                IntVector2 progression;
                progression = GetPositionSectorProgression(position, sectorInfo);
                IntVector2 newPosition = new IntVector2(sectorInfo.index.x + progression.x, sectorInfo.index.y + progression.y);
                sectorInfo = _mapInfoStoreController.UploadSectorInfo(newPosition);
                return GetSectorOfPosition(position, sectorInfo);
            }
        }

        private bool IsPositionInSector(ISectorInfo sectorInfo, IntVector2 position)
        {
            IntVector2 result = GetPositionSectorProgression(position, sectorInfo);
            if (result.x == 0 && result.y == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        private IntVector2 GetPositionSectorProgression(IntVector2 position, ISectorInfo sectorInfo)
        {
            int xProgression, yProgression;
            xProgression = GetSectorDimantionProgression(GetSectorRange(sectorInfo, true), position.x);
            yProgression = GetSectorDimantionProgression(GetSectorRange(sectorInfo, false), position.y);

            return new IntVector2(xProgression, yProgression);
        }
        

        private void UpdateCurrentSector1(IntVector2 progression)
        {
            if (progression.x == 0 && progression.y == 0)
            {
                return;
            }
            
            IntVector2 index = new IntVector2(
                _currentSector.index.x + progression.x, 
                _currentSector.index.y + progression.y 
                );
            
            UploadSector(index);
        }
        
        public Dictionary<IntVector2, IMapTileInfo> ActiveTiles
        {
            get { return _activeTiles;  }
        }
    }
}