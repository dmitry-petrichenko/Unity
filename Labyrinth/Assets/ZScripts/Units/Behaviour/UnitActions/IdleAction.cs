﻿using System;
using UnityEditor;
using UnityEngine;
using ZScripts.GameLoop;

namespace ZScripts.Units.UnitActions
{
    public class IdleAction : IUnitAction
    {
        private float delayTime;
        private IGameLoopController _gameloopController;
        private IOneUnitController _oneUnitController;
        
        public IdleAction(IGameLoopController gameloopController)
        {
            _gameloopController = gameloopController;
            delayTime = UnityEngine.Random.Range(1.0f, 5.0f);
        }

        public void Initialize(IOneUnitController oneUnitController)
        {
            _oneUnitController = oneUnitController;
        }
        
        public void Start()
        {
            _oneUnitController.Wait();
            _gameloopController.DelayStart(TriggerComplete, delayTime);
        }

        private void TriggerComplete()
        {
            if (OnComplete != null)
            {
                OnComplete();
            } 
        }
        
        public void Stop()
        {
           
        }

        public void Destroy()
        {
            
        }

        public event Action OnComplete;
    }
}