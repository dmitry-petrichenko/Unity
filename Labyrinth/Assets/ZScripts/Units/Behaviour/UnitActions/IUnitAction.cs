using System;

namespace ZScripts.Units
{
    public interface IUnitAction
    {
        void Start();
        void Stop();
        void Destroy();
        
        event Action OnComplete;
    }
}