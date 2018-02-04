using System;

namespace ZScripts.Units
{
    public class MoveController
    {
        private IOneUnitServicesContainer _unitController;
        private ISubMoveController _subMoveController;
        private MoveToHandlerController _moveToHandlerController;
        private MoveConsideringOccupatedController _moveConsideringOccupatedController;
         
        public event Action MoveToComplete;
        
        public MoveController(
            MoveToHandlerController moveToHandlerController,
            ISubMoveController subMoveController,
            MoveConsideringOccupatedController moveConsideringOccupatedController
            )
        {
            _subMoveController = subMoveController;
            _moveToHandlerController = moveToHandlerController;
            _moveConsideringOccupatedController = moveConsideringOccupatedController;
        }
        
        public void Initialize(IOneUnitServicesContainer unitController)
        {
            _unitController = unitController;
            _subMoveController.MoveToComplete += MoveToCompleteHandler;
            _subMoveController.Initialize(_unitController);
            _moveToHandlerController.Initialize(_subMoveController);
            _moveConsideringOccupatedController.Initialize(_subMoveController);
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
    }
}