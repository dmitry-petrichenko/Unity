using System.Collections.Generic;
using Zenject;
using ZScripts.Units.Behaviour.UnitActions;
using ZScripts.Units.Rotation;
using ZScripts.Units.StateInfo;

namespace ZScripts.Units
{
    public class AttackController
    {
        private IOneUnitController _unitController;
        private UnitBehaviourGenerator _unitBehaviourGenerator;
        private IOneUnitRotationController _oneUnitRotationController;
        private DiContainer _container;
        private OvertakeOccupatedPositionController _overtakeOccupatedPositionController;

        public AttackController(
            UnitBehaviourGenerator unitBehaviourGenerator,
            DiContainer container,
            IOneUnitRotationController oneUnitRotationController,
            OvertakeOccupatedPositionController overtakeOccupatedPositionController,
            IUnitStateInfo unitStateInfo
            )
        {
            _container = container;
            _unitBehaviourGenerator = unitBehaviourGenerator;
            _oneUnitRotationController = oneUnitRotationController;
            _overtakeOccupatedPositionController = overtakeOccupatedPositionController;
        }

        public void Initialize(IOneUnitController unitController)
        {
            _unitController = unitController;
            _overtakeOccupatedPositionController.Initialize(_unitController);
        }

        public void Cancel()
        {
            _unitBehaviourGenerator.Stop();
        }
        
        public void Attack(IntVector2 position)
        {
            // TODO MAKE BETTER 
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