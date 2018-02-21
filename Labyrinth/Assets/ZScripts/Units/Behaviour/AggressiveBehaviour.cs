using System;

namespace ZScripts.Units
{
    public class AggressiveBehaviour : IAgressiveBehaviour
    {
        public event Action Complete;

        private IOneUnitController _target;
        private IOneUnitController _oneUnitController;
        private readonly TargetOvertaker _targetOvertaker;
        private readonly AttackController _attackController;

        public AggressiveBehaviour(
            TargetOvertaker targetOvertaker,
            AttackController attackController
            )
        {
            _attackController = attackController;
            _targetOvertaker = targetOvertaker;
        }
        
        public void Initialize(IOneUnitController oneUnitController)
        {
            _oneUnitController = oneUnitController;
            
            _attackController.Initialize(_oneUnitController);
            _targetOvertaker.Initialize(_oneUnitController);
            
            _targetOvertaker.Complete += OnCopleteOvertake;
            _targetOvertaker.StartFollow += OnStartFollow;
            _targetOvertaker.TargetMoved += OnTargetMove;
        }
        
        public void Start(IOneUnitController target)
        {
            _target = target;
            _targetOvertaker.Overtake(_target);
        }

        private void OnStartFollow()
        {
            _attackController.Cancel();
        }

        private void OnCopleteOvertake()
        {
            _attackController.Attack(_target.Position);
        }
        
        private void OnTargetMove()
        {
            _attackController.Attack(_target.Position);
        }

        public void Cancel()
        {
            _attackController.Cancel();
            _targetOvertaker.Cancel();
        }

    }
}