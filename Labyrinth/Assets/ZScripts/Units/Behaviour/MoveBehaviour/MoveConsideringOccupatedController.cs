using System.Collections.Generic;
using ZScripts.Units.PathFinder;

namespace ZScripts.Units
{
    public class MoveConsideringOccupatedController
    {
        private readonly IUnitsTable _unitsTable;
        private ISubMoveController _subMoveController;
        private readonly IPathFinderController _pathFinderController;
        private List<IntVector2> _occupiedPossitions;
        
        public MoveConsideringOccupatedController(
            IUnitsTable unitsTable,
            IPathFinderController pathFinderController)
        {
            _unitsTable = unitsTable;
            _pathFinderController = pathFinderController;
        }

        public void Initialize(ISubMoveController subMoveController)
        {
            _subMoveController = subMoveController;
            _subMoveController.NextPositionOccupiedHandler += NextPositionOccupiedHandler;
        }

        private void NextPositionOccupiedHandler(IntVector2 occupiedPosition)
        {
            _subMoveController.Cancel();
            _occupiedPossitions = _unitsTable.GetOccupiedPositions();
            RemoveCurrentUnitPosition();
            List<IntVector2> newPath = _pathFinderController.GetPath(_subMoveController.Position,
                _subMoveController.Destination, _occupiedPossitions);
            _subMoveController.MoveTo(newPath);
        }

        private void RemoveCurrentUnitPosition()
        {
            List<IntVector2> copy;
            copy = CopyDictionary(_occupiedPossitions);
            _occupiedPossitions = copy;
            _occupiedPossitions.Remove(_subMoveController.Position);
        }
        
        private List<IntVector2> CopyDictionary(List<IntVector2> value)
        {
            List<IntVector2> copy = new List<IntVector2>();
            foreach (var index in value)
            {
                copy.Add(index);
            }

            return copy;
        }
    }
}