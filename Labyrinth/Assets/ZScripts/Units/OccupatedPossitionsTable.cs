using System.Collections.Generic;

namespace ZScripts.Units
{
    public class OccupatedPossitionsTable : IOccupatedPossitionsTable
    {
        private Dictionary<IntVector2, bool> _indexes = new Dictionary<IntVector2, bool>();

        public void SetOccupied(IntVector2 index)
        {
            _indexes[index] = false;
        }
        
        public void SetVacant(IntVector2 index)
        {
            _indexes.Remove(index);
        }

        public bool IsVacant(IntVector2 index)
        {
            if (_indexes.ContainsKey(index))
            {
                return _indexes[index];
            }

            return true;
        }

        public Dictionary<IntVector2, bool> GetOccupiedPossitions()
        {
            return _indexes;
        }
    }
}