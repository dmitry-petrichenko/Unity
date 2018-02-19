using System.Collections.Generic;
using Zenject;
using ZScripts.ActionDistributor;
using ZScripts.GameLoop;
using ZScripts.Units.UnitActions;

namespace ZScripts.Units
{
    public class PeacefulBehaviour : IPeacefulBehaviour
    {
        private IUnitAction _currentUnitAction;
        private IHeavyActionDistributor _heavyActionDistributor;
        private readonly DiContainer _container;
        private IOneUnitController _oneUnitController;
        private UnitBehaviourGenerator _unitBehaviourGenerator;

        public PeacefulBehaviour(
            IHeavyActionDistributor heavyActionDistributor, 
            DiContainer container,
            UnitBehaviourGenerator unitBehaviourGenerator
            )
        {
            _container = container;
            _heavyActionDistributor = heavyActionDistributor;
            _unitBehaviourGenerator = unitBehaviourGenerator;
        }
        
        public void Initialize(IOneUnitController oneUnitController)
        {
            _oneUnitController = oneUnitController;
        }

        public void Start()
        {
            List<IUnitAction> actions = new List<IUnitAction>();
            
            IUnitAction action;
            action = _container.Resolve<IdleAction>();
            action.Initialize(_oneUnitController);
            actions.Add(action);
            
            action = _container.Resolve<MoveToPositionAction>();
            action.Initialize(_oneUnitController);
            actions.Add(action);
            
            _unitBehaviourGenerator.Initialize(_oneUnitController, actions);
            
            _unitBehaviourGenerator.Start();
        }

        public void Stop()
        {
            _unitBehaviourGenerator.Stop();
        }

    }
}