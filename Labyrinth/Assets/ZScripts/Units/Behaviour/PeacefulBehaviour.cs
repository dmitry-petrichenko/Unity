using Zenject;
using ZScripts.ActionDistributor;
using ZScripts.GameLoop;
using ZScripts.Units.UnitActions;

namespace ZScripts.Units
{
    public class PeacefulBehaviour : IPeacefulBehaviour
    {
        private IUnitAction _currentUnitAction;
        private int i = 0;
        private IHeavyActionDistributor _heavyActionDistributor;
        private readonly DiContainer _container;
        private IOneUnitController _oneUnitController;

        public PeacefulBehaviour(IHeavyActionDistributor heavyActionDistributor, DiContainer container)
        {
            _container = container;
            _heavyActionDistributor = heavyActionDistributor;
        }
        
        public void Initialize(IOneUnitController oneUnitController)
        {
            _oneUnitController = oneUnitController;
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
            if (_currentUnitAction != null)
            {
                _currentUnitAction.Destroy();
                _currentUnitAction.OnComplete -= Proceed;
            }

            _currentUnitAction = GenerateUnitAction();
            _currentUnitAction.OnComplete += Proceed;
            //_currentUnitAction.Start();
            _heavyActionDistributor.InvokeDistributed(_currentUnitAction.Start);
        }

        private IUnitAction GenerateUnitAction()
        {
            IUnitAction action;
            float a = UnityEngine.Random.Range(0.0f, 1.0f);
            if (a < 0.5)
            {
                action = _container.Resolve<IdleAction>();
            }
            else
            {
                action = _container.Resolve<MoveToPositionAction>(); 
            }  
            action.Initialize(_oneUnitController);
            
            return action;
        }
    }
}