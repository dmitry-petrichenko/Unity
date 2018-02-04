using System;

namespace ZScripts.Units
{
    public class MoveController
    {
        private IOneUnitServicesContainer _unitController;
        private ISubMoveController _subMoveController;
        private MoveToHandlerController _moveToHandlerController;
         
        public event Action MoveToComplete;
        
        public MoveController(
            MoveToHandlerController moveToHandlerController,
            ISubMoveController subMoveController
            )
        {
            _subMoveController = subMoveController;
            _moveToHandlerController = moveToHandlerController;
        }
        
        public void Initialize(IOneUnitServicesContainer unitController)
        {
            _unitController = unitController;
            _subMoveController.MoveToComplete += MoveToCompleteHandler;
            _subMoveController.Initialize(_unitController);
            _moveToHandlerController.Initialize(_subMoveController);
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