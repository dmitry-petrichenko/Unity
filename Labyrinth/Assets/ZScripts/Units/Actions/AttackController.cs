namespace ZScripts.Units
{
    public class AttackController
    {
        private IOneUnitController _unitController;

        public void Initialize(IOneUnitController unitController)
        {
            _unitController = unitController;
        }
    }
}