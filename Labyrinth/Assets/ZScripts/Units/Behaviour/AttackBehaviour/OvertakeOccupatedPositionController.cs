using UnityEngine;
using ZScripts.Units.PathFinder;
using ZScripts.Units.StateInfo;

namespace ZScripts.Units
{
    public class OvertakeOccupatedPositionController
    {
        private readonly INoWayEventRouter _noWayEventRouter;
        private IOneUnitController _oneUnitController;
        private IUnitsTable _unitsTable;
        private ISubMoveController _subMoveController;
        private IUnitStateInfo _unitStateInfo;
        private IGrid _grid;
        
        public OvertakeOccupatedPositionController(
            INoWayEventRouter noWayEventRouter,
            IUnitsTable unitsTable,
            ISubMoveController subMoveController,
            IUnitStateInfo unitStateInfo,
            IGrid grid
            )
        {
            _noWayEventRouter = noWayEventRouter;
            _unitsTable = unitsTable;
            _subMoveController = subMoveController;
            _unitStateInfo = unitStateInfo;
            _grid = grid;
        }
        
        public void Initialize(IOneUnitController oneUnitController)
        {
            _oneUnitController = oneUnitController;
            _noWayEventRouter.NoWayToAttackPointHandler += NoWayToAttackPointHandler;
        }

        private void NoWayToAttackPointHandler(IntVector2 position)
        {
            IntVector2 freePosition = GetFirstFreePositionInUnitRange(_unitStateInfo.AttackTarget.Position);
            if (IntVector2.AreEqual(freePosition, IntVector2.UNASSIGNET))
            {
               Debug.Log("NO_WAY_TO_ATTACK_POINT");
            }
            
            _oneUnitController.MoveTo(freePosition);
        }

        private IntVector2 GetFirstFreePositionInUnitRange(IntVector2 position)
        {
            IntVector2 position1 = new IntVector2(position.x - 1, position.y + 1);
            if (IsFreePosition(position1)) return position1;
            position1 = new IntVector2(position.x - 1, position.y);
            if (IsFreePosition(position1)) return position1;
            position1 = new IntVector2(position.x - 1, position.y - 1);
            if (IsFreePosition(position1)) return position1;
            position1 = new IntVector2(position.x, position.y - 1);
            if (IsFreePosition(position1)) return position1;
            position1 = new IntVector2(position.x + 1, position.y - 1);
            if (IsFreePosition(position1)) return position1;
            position1 = new IntVector2(position.x + 1, position.y + 1);
            if (IsFreePosition(position1)) return position1;
            position1 = new IntVector2(position.x, position.y + 1);
            if (IsFreePosition(position1)) return position1;
            position1 = new IntVector2(position.x + 1, position.y);
            if (IsFreePosition(position1)) return position1;

            return IntVector2.UNASSIGNET;
        }
        
        private bool IsFreePosition(IntVector2 position)
        {
            return _grid.GetCell(position) && _unitsTable.IsVacantPosition(position);
        }
    }
}