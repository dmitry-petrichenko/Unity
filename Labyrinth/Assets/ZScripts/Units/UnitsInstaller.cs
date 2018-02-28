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
        Container.Bind<IPathFinderController>().To<PathFinderController>().AsSingle();
        Container.Bind<IGrid>().To<Grid>().AsSingle();
        Container.Bind<MoveToPositionAction>().To<MoveToPositionAction>().AsTransient();
        Container.Bind<IOccupatedPossitionsTable>().To<OccupatedPossitionsTable>().AsSingle();
        Container.Bind<IUnitsTable>().To<UnitsTable>().AsSingle();
        Container.Bind<IMovingRandomizer>().To<MovingRandomizer>().AsSingle();
        Container.Bind<UnitBehaviourGenerator>().To<UnitBehaviourGenerator>().AsTransient();
        
        Container.Bind<EnemyController>().To<EnemyController>().FromSubContainerResolve().ByMethod(InstallEnemyController).AsTransient();
        Container.Bind<IPlayerController>().To<PlayerController>().FromSubContainerResolve().ByMethod(InstallPlayerController).AsSingle();
    }
    
    private void InstallPlayerController(DiContainer subContainer)
    {
        subContainer.Bind<PlayerController>().AsSingle();
        InstallOneUnitSubComponents(subContainer);
    }
    
    private void InstallEnemyController(DiContainer subContainer)
    {
        subContainer.Bind<EnemyController>().AsSingle();
        InstallOneUnitSubComponents(subContainer);
    }

    private void InstallOneUnitSubComponents(DiContainer subContainer)
    {
        subContainer.Bind<MoveController>().To<MoveController>().AsSingle();
        subContainer.Bind<ISubMoveController>().To<SubMoveController>().AsSingle();
        subContainer.Bind<MoveToHandlerController>().To<MoveToHandlerController>().AsSingle();
        subContainer.Bind<AttackController>().To<AttackController>().AsSingle();
        subContainer.Bind<IAgressiveBehaviour>().To<AggressiveBehaviour>().AsSingle();
        subContainer.Bind<IOneUnitAnimationController>().To<OneUnitAnimationController>().AsSingle();
        subContainer.Bind<IOneUnitRotationController>().To<OneUnitRotationController>().AsSingle();
        subContainer.Bind<IOneUnitMotionController>().To<OneUnitMotionController>().AsSingle();
        subContainer.Bind<IPeacefulBehaviour>().To<PeacefulBehaviour>().AsSingle();
        subContainer.Bind<IUnitSettings>().To<UnitSettings>().AsSingle();
        subContainer.Bind<WaitMoveTurnController>().To<WaitMoveTurnController>().AsSingle();
        subContainer.Bind<MoveConsideringOccupatedController>().To<MoveConsideringOccupatedController>().AsSingle();
        subContainer.Bind<IUnitStateInfo>().To<UnitStateInfo>().AsSingle();
        subContainer.Bind<TargetOvertaker>().To<TargetOvertaker>().AsSingle();
        subContainer.Bind<IdleAction>().To<IdleAction>().AsTransient();
        subContainer.Bind<AttackAction>().To<AttackAction>().AsTransient();
        subContainer.Bind<INoWayEventRouter>().To<NoWayEventRouter>().AsSingle();
        subContainer.Bind<OvertakeOccupatedPositionController>().To<OvertakeOccupatedPositionController>().AsSingle();
    }
}