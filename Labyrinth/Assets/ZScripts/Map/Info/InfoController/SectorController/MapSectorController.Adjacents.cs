namespace ZScripts.Map.Info
{
    public partial class MapSectorController
    {     

        private void UpdateAdjacents(IntVector2 position)
        {
            IntVector2 progression = GetPositionVisibleProgression(position, _currentSector);
            IntVector2 newPosition = new IntVector2(_currentSector.index.x + progression.x, _currentSector.index.y + progression.y);
            UploadSector(newPosition);
        }

        private IntVector2 GetPositionVisibleRange(IntVector2 position, bool xDimention)
        {
            int startValue, endValue;
          
            if (xDimention)
            {
                startValue = position.x - _settings.ActiveAreaSize / 2;
                endValue = position.x + _settings.ActiveAreaSize / 2;
                return new IntVector2(startValue, endValue);
            }
            else
            {
                startValue = position.y - _settings.ActiveAreaSize / 2;
                endValue = position.y + _settings.ActiveAreaSize / 2;
                return new IntVector2(startValue, endValue);
            }
        }

        private int GetVisibleDimantionProgression(IntVector2 sectorRange, IntVector2 visibleRange)
        {
            if (sectorRange.x > visibleRange.x)
            {
                return -1;
            }
            else if (sectorRange.y < visibleRange.y)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        
        private IntVector2 GetPositionVisibleProgression(IntVector2 position, ISectorInfo sectorInfo)
        {
            int xProgression, yProgression;
            xProgression = GetVisibleDimantionProgression(GetSectorRange(sectorInfo, true), GetPositionVisibleRange(position, true));
            yProgression = GetVisibleDimantionProgression(GetSectorRange(sectorInfo, false), GetPositionVisibleRange(position, false));

            return new IntVector2(xProgression, yProgression);
        }
    }
}