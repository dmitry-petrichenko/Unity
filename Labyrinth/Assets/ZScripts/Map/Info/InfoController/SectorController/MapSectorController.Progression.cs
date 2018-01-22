using UnityEngine;
using ZScripts.Settings;
using ZScripts.Units;

namespace ZScripts.Map.Info
{
    public partial class MapSectorController
    {
        private IntVector2 GetSectorRange(ISectorInfo sectorInfo, bool xDimention)
        {
            int startValue, endValue;
          
            if (xDimention)
            {
                startValue = sectorInfo.startPoint.x;
                endValue = sectorInfo.startPoint.x + sectorInfo.size.x - 1;
                return new IntVector2(startValue, endValue);
            }
            else
            {
                startValue = sectorInfo.startPoint.y;
                endValue = sectorInfo.startPoint.y + sectorInfo.size.y - 1;
                return new IntVector2(startValue, endValue);
            }
        }

        private int GetSectorDimantionProgression(IntVector2 range, int playerPosition)
        {
            if (playerPosition > range.y)
            {
                return 1;
            }
            else if (playerPosition < range.x)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }


    }
}