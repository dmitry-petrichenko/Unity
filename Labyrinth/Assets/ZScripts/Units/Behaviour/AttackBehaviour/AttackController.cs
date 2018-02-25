using System.Collections.Generic;
using Zenject;
using ZScripts.Units.Behaviour.UnitActions;
using ZScripts.Units.Rotation;

namespace ZScripts.Units
{
    public class AttackController
    {
        private IOneUnitController _unitController;
        private UnitBehaviourGenerator _unitBehaviourGenerator;
        private IOneUnitRotationController _oneUnitRotationController;
        private DiContainer _container;

        public AttackController(
            UnitBehaviourGenerator unitBehaviourGenerator,
            DiContainer container,
            IOneUnitRotationController oneUnitRotationController
            )
        {
            _container = container;
            _unitBehaviourGenerator = unitBehaviourGenerator;
            _oneUnitRotationController = oneUnitRotationController;
        }

        public void Initialize(IOneUnitController unitController)
        {
            _unitController = unitController;
        }

        public void Cancel()
        {
            _unitBehaviourGenerator.Stop();
        }
        
        public void Attack(IntVector2 position)
        {
            _oneUnitRotationController.Rotate(_unitController.Position, position);
            
            List<IUnitAction> actions = new List<IUnitAction>();
            
            AttackAction action;
            action = _container.Resolve<AttackAction>();
            actions.Add(action);
            
            _unitBehaviourGenerator.Initialize(_unitController, actions);
            _unitBehaviourGenerator.Start();
        }
    }
}