using Units;
using Zenject;
using ZScripts.Units;
using ZScripts.Units.Behaviour.UnitActions;
using ZScripts.Units.Enemy;
using ZScripts.Units.PathFinder;
using ZScripts.Units.Player;
using ZScripts.Units.Rotation;
using ZScripts.Units.Settings;
using ZScripts.Units.StateInfo;
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
        Container.Bind<AttackAction>().To<AttackAction>().AsTransient();
        Container.Bind<MoveToPositionAction>().To<MoveToPositionAction>().AsTransient();
        Container.Bind<IUnitSettings>().To<UnitSettings>().AsTransient();
        Container.Bind<ISubMoveController>().To<SubMoveController>().AsTransient();
        Container.Bind<MoveToHandlerController>().To<MoveToHandlerController>().AsTransient();
        Container.Bind<IOccupatedPossitionsTable>().To<OccupatedPossitionsTable>().AsSingle();
        Container.Bind<MoveConsideringOccupatedController>().To<MoveConsideringOccupatedController>().AsTransient();
        Container.Bind<WaitMoveTurnController>().To<WaitMoveTurnController>().AsTransient();
        Container.Bind<IUnitsTable>().To<UnitsTable>().AsSingle();
        Container.Bind<IMovingRandomizer>().To<MovingRandomizer>().AsSingle();
        Container.Bind<IUnitStateInfo>().To<UnitStateInfo>().AsTransient();
        Container.Bind<UnitBehaviourGenerator>().To<UnitBehaviourGenerator>().AsTransient();
        Container.Bind<IAgressiveBehaviour>().To<AggressiveBehaviour>().AsTransient();
        Container.Bind<TargetOvertaker>().To<TargetOvertaker>().AsTransient();
    }
}