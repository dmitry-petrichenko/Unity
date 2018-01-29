using System;
using System.Collections;
using UnityEngine;

namespace ZScripts.Units.UnitActions
{
    public class IdleAction : IUnitAction
    {
        public IdleAction()
        {
            
        }
        
        public void Start()
        {
            Debug.Log("start");
            Debug.Log("complete");
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