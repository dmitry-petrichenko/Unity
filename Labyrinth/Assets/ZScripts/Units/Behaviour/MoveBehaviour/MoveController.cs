using System;

namespace ZScripts.Units
{
    public class MoveController : EventDispatcher
    {
        private IOneUnitController _unitController;
        private ISubMoveController _subMoveController;
        private MoveToHandlerController _moveToHandlerController;
        private MoveConsideringOccupatedController _moveConsideringOccupatedController;
        private WaitMoveTurnController _waitMoveTurnController;
         
        public event Action MoveToComplete;
        public event Action MoveOneStepComplete;
        public event Action StartMove;
        
        public MoveController(
            MoveToHandlerController moveToHandlerController,
            ISubMoveController subMoveController,
            MoveConsideringOccupatedController moveConsideringOccupatedController,
            WaitMoveTurnController waitMoveTurnController
            )
        {
            _waitMoveTurnController = waitMoveTurnController;
            _subMoveController = subMoveController;
            _moveToHandlerController = moveToHandlerController;
            _moveConsideringOccupatedController = moveConsideringOccupatedController;
        }
        
        public void Initialize(IOneUnitController unitController)
        {
            _unitController = unitController;
            
            _subMoveController.MoveToComplete += MoveToCompleteHandler;
            _subMoveController.MoveStepComplete += MoveOneStepCompleteHandler;
            _subMoveController.StartMove += StartMoveHandler;
            
            _subMoveController.Initialize(_unitController);
            _moveToHandlerController.Initialize(_subMoveController);
            _moveConsideringOccupatedController.Initialize(_subMoveController);
            _waitMoveTurnController.Initialize(_subMoveController, _unitController);
        }

        private void MoveOneStepCompleteHandler()
        {
            DispatchEvent(MoveOneStepComplete);
        }

        private void MoveToCompleteHandler()
        {
            DispatchEvent(MoveToComplete);
        }

        private void StartMoveHandler()
        {
            DispatchEvent(StartMove);
        }
        
        public void MoveTo(IntVector2 position)
        {
            _moveToHandlerController.MoveTo(position);
        }
        
        public void SetOnPosition(IntVector2 position)
        {
            _subMoveController.SetOnPosition(position);
        }
    }
}