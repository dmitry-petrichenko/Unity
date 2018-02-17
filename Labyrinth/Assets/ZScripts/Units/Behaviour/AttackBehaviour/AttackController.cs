namespace ZScripts.Units
{
    public class AttackController
    {
        private IOneUnitController _unitController;

        public void Initialize(IOneUnitController unitController)
        {
            _unitController = unitController;
        }

        public void Cancel()
        {
            
        }
        
        public void Attack(IntVector2 position)
        {
            
        }
    }
}