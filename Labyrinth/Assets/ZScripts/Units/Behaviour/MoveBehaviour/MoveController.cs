using System;

namespace ZScripts.Units
{
    public class MoveController
    {
        private IOneUnitServicesContainer _unitController;
        private ISubMoveController _subMoveController;
        private MoveToHandlerController _moveToHandlerController;
        private MoveConsideringOccupatedController _moveConsideringOccupatedController;
        private WaitMoveTurnController _waitMoveTurnController;
         
        public event Action MoveToComplete;
        public event Action MoveOneStepComplete;
        
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
        
        public void Initialize(IOneUnitServicesContainer unitController)
        {
            _unitController = unitController;
            
            _subMoveController.MoveToComplete += MoveToCompleteHandler;
            _unitController.MotionController.CompleteMove += MoveOneStepCompleteHandler;
            
            _subMoveController.Initialize(_unitController);
            _moveToHandlerController.Initialize(_subMoveController);
            _moveConsideringOccupatedController.Initialize(_subMoveController);
            _waitMoveTurnController.Initialize(_subMoveController, _unitController);
        }

        private void MoveOneStepCompleteHandler()
        {
            if (MoveOneStepComplete != null)
            {
                MoveOneStepComplete();
            }
        }

        private void MoveToCompleteHandler()
        {
            if (MoveToComplete != null)
            {
                MoveToComplete();
            }
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