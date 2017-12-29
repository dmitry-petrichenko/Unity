using System;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Installers/GameSettingsInstaller")]
public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
{
    public TestInstaller.GameSettings TestInstaller;
        
    public override void InstallBindings()
    {
        Container.BindInstance(TestInstaller);
    }
}