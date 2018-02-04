using System.Collections.Generic;

namespace ZScripts.Units
{
    public interface IOccupatedPossitionsTable
    {
        void SetVacant(IntVector2 index);
        bool IsVacant(IntVector2 index);
        void SetOccupied(IntVector2 index);
        Dictionary<IntVector2, bool> GetOccupiedPossitions();
    }
}