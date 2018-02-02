using Units;
using Zenject;
using ZScripts.Units;
using ZScripts.Units.Enemy;
using ZScripts.Units.PathFinder;
using ZScripts.Units.Player;
using ZScripts.Units.Rotation;
using ZScripts.Units.UnitActions;

public class UnitsInstaller : Installer<UnitsInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<UnitsController>().To<UnitsController>().AsSingle().NonLazy();
        Container.Bind<IPlayerController>().To<PlayerController>().AsSingle();
        Container.Bind<MoveController>().To<MoveController>().AsTransient();
        Container.Bind<AttackController>().To<AttackController>().AsTransient();
        Container.Bind<IPathFinderController>().To<PathFinderController>().AsSingle();
        Container.Bind<IGrid>().To<Grid>().AsSingle();
        Container.Bind<IOneUnitAnimationController>().To<OneUnitAnimationController>().AsTransient();
        Container.Bind<IOneUnitRotationController>().To<OneUnitRotationController>().AsTransient();
        Container.Bind<IOneUnitMotionController>().To<OneUnitMotionController>().AsTransient();
        Container.Bind<EnemyController>().To<EnemyController>().AsTransient();
        Container.Bind<IPeacefulBehaviour>().To<PeacefulBehaviour>().AsTransient();
        Container.Bind<IdleAction>().To<IdleAction>().AsTransient();
        Container.Bind<MoveToPositionAction>().To<MoveToPositionAction>().AsTransient();
    }
}