﻿using System.Collections.Generic;
using ZScripts.ActionDistributor;

namespace ZScripts.Units
{
    public class UnitBehaviourGenerator
    {
        private IOneUnitController _oneUnitController;
        private List<IUnitAction> _actions;
        private IUnitAction _currentUnitAction;
        private IHeavyActionDistributor _heavyActionDistributor;
        
        public UnitBehaviourGenerator(IHeavyActionDistributor heavyActionDistributor)
        {
            _heavyActionDistributor = heavyActionDistributor;
        }

        public void Initialize(IOneUnitController oneUnitController, List<IUnitAction> actions)
        {
            _oneUnitController = oneUnitController;
            _actions = actions;
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
            _heavyActionDistributor.InvokeDistributed(_currentUnitAction.Start);
        }
        
        private IUnitAction GenerateUnitAction()
        {
            IUnitAction action;
            int a = (int)UnityEngine.Random.Range(0.0f, _actions.Count);
            action = _actions[a];
            
            action.Initialize(_oneUnitController);
            
            return action;
        }
    }
}