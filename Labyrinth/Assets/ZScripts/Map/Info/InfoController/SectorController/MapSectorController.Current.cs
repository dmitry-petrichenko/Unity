using System.Collections.Generic;

namespace ZScripts.Map.Info
{
    public partial class MapSectorController
    {     
        private ISectorInfo _currentSector;
        private Dictionary<IntVector2, ISectorInfo> _loadedSections = new Dictionary<IntVector2, ISectorInfo>();
        private Dictionary<IntVector2, IMapTileInfo> _activeTiles = new Dictionary<IntVector2, IMapTileInfo>();
        
        private void InitializeCurrentSector()
        {
            UploadSector(new IntVector2(0, 0));
        }

        private void UploadSector(IntVector2 index)
        {
            Dictionary<IntVector2, IMapTileInfo> uploadedTiles;
            
            _currentSector = _mapInfoStoreController.UploadSectorInfo(index);
            _loadedSections[_currentSector.index] = _currentSector;
            
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

        private void UpdateCurrentSector(IntVector2 progression)
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