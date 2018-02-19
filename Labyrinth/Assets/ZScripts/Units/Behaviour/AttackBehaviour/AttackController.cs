using System.Collections.Generic;
using Zenject;
using ZScripts.Units.Behaviour.UnitActions;

namespace ZScripts.Units
{
    public class AttackController
    {
        private IOneUnitController _unitController;
        private UnitBehaviourGenerator _unitBehaviourGenerator;
        private DiContainer _container;

        public AttackController(
            UnitBehaviourGenerator unitBehaviourGenerator,
            DiContainer container
            )
        {
            _container = container;
            _unitBehaviourGenerator = unitBehaviourGenerator;
        }

        public void Initialize(IOneUnitController unitController)
        {
            _unitController = unitController;
        }

        public void Cancel()
        {
            
        }
        
        public void Attack(IntVector2 position)
        {
            List<IUnitAction> actions = new List<IUnitAction>();
            
            AttackAction action;
            action = _container.Resolve<AttackAction>();
            action.Initialize(_unitController, position);
            actions.Add(action);
            
            _unitBehaviourGenerator.Initialize(_unitController, actions);
            _unitBehaviourGenerator.Start();
        }
    }
}