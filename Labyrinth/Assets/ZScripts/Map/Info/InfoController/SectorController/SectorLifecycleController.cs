using System.Collections.Generic;
using UnityEngine;

namespace ZScripts.Map.Info
{
    public class SectorLifecycleController
    {
        private readonly IMapInfoStoreController _mapInfoStoreController;
        private Dictionary<IntVector2, ISectorInfo> _activeSectors = new Dictionary<IntVector2, ISectorInfo>();
        private Dictionary<IntVector2, ISectorInfo> _loadedSections = new Dictionary<IntVector2, ISectorInfo>();
        private Dictionary<IntVector2, IMapTileInfo> _activeTiles;

        public SectorLifecycleController(IMapInfoStoreController mapInfoStoreController)
        {
            _mapInfoStoreController = mapInfoStoreController;
        }
        
        public void Initialize(Dictionary<IntVector2, IMapTileInfo> activeTiles)
        {
            _activeTiles = activeTiles;
            _activeSectors[new IntVector2(0, 0)] = new SectorInfo();
            _activeSectors[new IntVector2(1, 0)] = new SectorInfo();
            Dictionary<IntVector2, ISectorInfo> copy = CopyDictionary(_activeSectors);
            Debug.Log(copy);
            _activeSectors.Remove(new IntVector2(1, 0));
        }
        
        public void AddActiveSector(ISectorInfo sectorInfo)
        {
            _activeSectors[sectorInfo.index] = sectorInfo;
        }
        
        public void UpdateSectors()
        {
            Dictionary<IntVector2, ISectorInfo> _sectorsToRemove;
            Dictionary<IntVector2, ISectorInfo> _sectorsToUpload;

            _sectorsToRemove = DictionarySubtraction(_loadedSections, _activeSectors);
            _sectorsToUpload = DictionarySubtraction(_activeSectors, _loadedSections);

            _loadedSections = CopyDictionary(_activeSectors);
            _activeSectors = new Dictionary<IntVector2, ISectorInfo>();

            UploadSectors(_sectorsToUpload);
            RemoveSectors(_sectorsToRemove);
        }

        private void RemoveSectors(Dictionary<IntVector2, ISectorInfo> sectorsToRemove)
        {
            foreach (var info in sectorsToRemove)
            {
                RemoveTilesInSection(info.Value);
            }
        }
        
        private void RemoveTilesInSection(ISectorInfo sectionInfo)
        {
            IntVector2 index;
            for (int i = sectionInfo.startPoint.x; i < sectionInfo.startPoint.x + sectionInfo.size.x; i++)
            {
                for (int j = sectionInfo.startPoint.y; j < sectionInfo.startPoint.y + sectionInfo.size.y; j++)
                {
                    index = new IntVector2(i, j);
                    if (_activeTiles.ContainsKey(index))
                    {
                        _activeTiles.Remove(index);
                    }
                }
            }
        }

        private void UploadSectors(Dictionary<IntVector2, ISectorInfo> sectorsToUpload)
        {
            Dictionary<IntVector2, IMapTileInfo> uploadedTiles;
            
            foreach (var sectorInfo in sectorsToUpload)
            {
                uploadedTiles = _mapInfoStoreController.UploadSectorData(sectorInfo.Value.index);
                UploadSector(uploadedTiles);
            }
        }

        private void UploadSector(Dictionary<IntVector2, IMapTileInfo> uploadedTiles)
        {
            foreach (var info in uploadedTiles)
            {
                _activeTiles[info.Key] = info.Value;
            }
        }

        private Dictionary<IntVector2, ISectorInfo> DictionarySubtraction(
            Dictionary<IntVector2, ISectorInfo> minued,
            Dictionary<IntVector2, ISectorInfo> subtranend
        )
        {
            Dictionary<IntVector2, ISectorInfo> minuedCopy = CopyDictionary(minued);
            foreach (var sectorInfo in subtranend)
            {
                if (minuedCopy.ContainsKey(sectorInfo.Key))
                {
                    minuedCopy.Remove(sectorInfo.Key);
                }
            }

            return minuedCopy;
        }

        private Dictionary<IntVector2, ISectorInfo> CopyDictionary(Dictionary<IntVector2, ISectorInfo> value)
        {
            Dictionary<IntVector2, ISectorInfo> copy = new Dictionary<IntVector2, ISectorInfo>();
            foreach (var sectorInfo in value)
            {
                copy[sectorInfo.Key] = sectorInfo.Value;
            }

            return copy;
        }
    }
}