using UnityEngine;
using Zenject;

namespace ZScripts
{
    [CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "GameSettingsInstaller")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        public GameInstaller.MapGraphicsList MapGraphicsList;
        
        public override void InstallBindings()
        {
            Container.BindInstance(MapGraphicsList);
        }
    }
}