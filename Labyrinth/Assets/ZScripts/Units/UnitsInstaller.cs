using Units;
using Zenject;
using ZScripts.Units;
using ZScripts.Units.Enemy;
using ZScripts.Units.PathFinder;
using ZScripts.Units.Player;
using ZScripts.Units.Rotation;

public class UnitsInstaller : Installer<UnitsInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<IUnitsController>().To<UnitsController>().AsSingle().NonLazy();
        Container.Bind<IPlayerController>().To<PlayerController>().AsSingle();
        Container.Bind<IOneUnitMotionController>().To<OneUnitMotionController>().AsTransient();
        //Container.Bind<IOneUnitController>().To<OneUnitController>().AsTransient();
        Container.Bind<MoveController>().To<MoveController>().AsTransient();
        Container.Bind<AttackController>().To<AttackController>().AsTransient();
        Container.Bind<IPathFinderController>().To<PathFinderController>().AsSingle();
        Container.Bind<IGrid>().To<Grid>().AsSingle();
        Container.Bind<IOneUnitAnimationController>().To<OneUnitAnimationController>().AsTransient();
        Container.Bind<IOneUnitRotationController>().To<OneUnitRotationController>().AsTransient();
        Container.Bind<EnemyController>().To<EnemyController>().AsSingle().NonLazy();
        Container.Bind<IPeacefulBehaviour>().To<PeacefulBehaviour>().AsSingle().NonLazy();
    }
}