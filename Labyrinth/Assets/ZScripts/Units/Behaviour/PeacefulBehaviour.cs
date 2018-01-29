using ZScripts.Units.UnitActions;

namespace ZScripts.Units
{
    public class PeacefulBehaviour : IPeacefulBehaviour
    {
        private IUnitAction _currentUnitAction;
        private int i = 0;
        
        public void Initialize(IOneUnitController oneUnitController)
        {
            
        }

        public void Start()
        {
            Proceed();
        }

        public void Stop()
        {
            
        }

        private void Proceed()
        {
            i++;
            if(i > 10)
            {return;}
            
            if (_currentUnitAction != null)
            {
                _currentUnitAction.Destroy();
                _currentUnitAction.OnComplete -= Proceed;
            }

            _currentUnitAction = GenerateUnitAction();
            _currentUnitAction.OnComplete += Proceed;
            _currentUnitAction.Start();
            
        }

        private IUnitAction GenerateUnitAction()
        {
            return new IdleAction();
        }
    }
}