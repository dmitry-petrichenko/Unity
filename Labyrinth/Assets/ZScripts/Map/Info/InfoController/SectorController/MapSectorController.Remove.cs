using System.Collections.Generic;

namespace ZScripts.Map.Info
{
    public partial class MapSectorController
    {
        private Dictionary<IntVector2, ISectorInfo> _activeSectors = new Dictionary<IntVector2, ISectorInfo>();
        private Dictionary<IntVector2, ISectorInfo> _loadedSections = new Dictionary<IntVector2, ISectorInfo>();
        
        private void RemoveUnusedTiles()
        {
            foreach (var info in _activeSectors)
            {
                if (_loadedSections.ContainsKey(info.Key))
                {
                    _loadedSections.Remove(info.Key);
                }
            }

            RemoveTilesInSections(_loadedSections);
            
            _loadedSections = new Dictionary<IntVector2, ISectorInfo>();
            foreach (var info in _activeSectors)
            {
                _loadedSections[info.Key] = info.Value;
            }
            _activeSectors = new Dictionary<IntVector2, ISectorInfo>();
        }

        private void RemoveTilesInSections(Dictionary<IntVector2, ISectorInfo> loadedSections)
        {
            foreach (var info in loadedSections)
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
    }
}