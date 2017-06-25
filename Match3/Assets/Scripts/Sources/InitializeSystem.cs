using Entitas;
using UnityEngine;

public class InitializeSystem : IInitializeSystem
{
    private Contexts _contexts;
    
    public InitializeSystem (Contexts contexts)
    {
        _contexts = contexts;
    }
   
    public void Initialize()
    {
        Debug.Log("Hello");
    }
}
