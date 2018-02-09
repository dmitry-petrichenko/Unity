namespace ZScripts.Units
{
    public class WaitMoveTurnController
    {
        public WaitMoveTurnController()
        {
            
        }
        
        private ISubMoveController _subMoveController;
        
        public void Initialize(ISubMoveController subMoveController)
        {
            _subMoveController = subMoveController;
            _subMoveController.NoWayToPointHandler += NoWayToPointHandler;
        }

        private void NoWayToPointHandler(IntVector2 destination)
        {
            
        }
    }
}