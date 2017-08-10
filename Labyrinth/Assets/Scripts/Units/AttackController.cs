namespace Units
{
    public class AttackController
    {
        private IUnitController _unitController;
        
        public void Initialize(IUnitController unitController)
        {
            _unitController = unitController;
        }
    }
}