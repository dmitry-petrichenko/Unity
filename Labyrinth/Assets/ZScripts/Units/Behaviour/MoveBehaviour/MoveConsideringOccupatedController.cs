using System.Collections.Generic;
using ZScripts.Units.PathFinder;

namespace ZScripts.Units
{
    public class MoveConsideringOccupatedController
    {
        private readonly IOccupatedPossitionsTable _occupatedPossitionsTable;
        private ISubMoveController _subMoveController;
        private readonly IPathFinderController _pathFinderController;
        private Dictionary<IntVector2, bool> _occupiedPossitions;
        
        public MoveConsideringOccupatedController(
            IOccupatedPossitionsTable occupatedPossitionsTable,
            IPathFinderController pathFinderController)
        {
            _occupatedPossitionsTable = occupatedPossitionsTable;
            _pathFinderController = pathFinderController;
        }

        public void Initialize(ISubMoveController subMoveController)
        {
            _subMoveController = subMoveController;
            _subMoveController.NextPositionOccupiedHandler += NextPositionOccupiedHandler;
        }

        private void NextPositionOccupiedHandler()
        {
            _subMoveController.Cancel();
            _occupiedPossitions = _occupatedPossitionsTable.GetOccupiedPossitions();
            RemoveCurrentUnitPosition();
            List<IntVector2> newPath = _pathFinderController.GetPath(_subMoveController.Position,
                _subMoveController.Destination, _occupiedPossitions);
            _subMoveController.MoveTo(newPath);
        }

        private void RemoveCurrentUnitPosition()
        {
            Dictionary<IntVector2, bool> copy;
            copy = CopyDictionary(_occupiedPossitions);
            _occupiedPossitions = copy;
            _occupiedPossitions.Remove(_subMoveController.Position);
        }
        
        private Dictionary<IntVector2, bool> CopyDictionary(Dictionary<IntVector2, bool> value)
        {
            Dictionary<IntVector2, bool> copy = new Dictionary<IntVector2, bool>();
            foreach (var index in value)
            {
                copy[index.Key] = index.Value;
            }

            return copy;
        }
    }
}