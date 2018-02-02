using Zenject;
using ZScripts.GameLoop;
using ZScripts.Units.UnitActions;

namespace ZScripts.Units
{
    public class PeacefulBehaviour : IPeacefulBehaviour
    {
        private IUnitAction _currentUnitAction;
        private int i = 0;
        private IGameLoopController _gameloopController;
        private readonly DiContainer _container;
        private IOneUnitController _oneUnitController;

        public PeacefulBehaviour(IGameLoopController gameloopController, DiContainer container)
        {
            _container = container;
            _gameloopController = gameloopController;
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
            _currentUnitAction.Start();
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