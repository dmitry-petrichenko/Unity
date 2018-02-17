﻿using System;

namespace ZScripts.Units
{
    public class AggressiveBehaviour : IAgressiveBehaviour
    {
        public event Action Complete;

        private IOneUnitController _target;
        private readonly TargetOvertaker _targetOvertaker;
        private readonly AttackController _attackController;

        public AggressiveBehaviour(
            TargetOvertaker targetOvertaker,
            AttackController attackController
            )
        {
            _attackController = attackController;
            _targetOvertaker = targetOvertaker;
            _targetOvertaker.Complete += OnCopleteOvertake;
            _targetOvertaker.StartFollow += OnStartFollow;
            _targetOvertaker.TargetMoved += OnTargetMove;
        }
        
        public void Start(IOneUnitController target)
        {
            _targetOvertaker.Overtake(target);
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