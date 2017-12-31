using Zenject;
using ZScripts.Units;
using ZScripts.Units.PathFinder;
using ZScripts.Units.Player;

public class UnitsInstaller : Installer<UnitsInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<IUnitsController>().To<UnitsController>().AsSingle().NonLazy();
        Container.Bind<PlayerController>().To<PlayerController>().AsSingle();
        Container.Bind<IOneUnitGraphicsController>().To<OneUnitGraphicsController>().AsTransient();
        Container.Bind<IOneUnitController>().To<OneUnitController>().AsTransient();
        Container.Bind<MoveController>().To<MoveController>().AsTransient();
        Container.Bind<AttackController>().To<AttackController>().AsTransient();
        Container.Bind<IPathFinderController>().To<PathFinderController>().AsSingle();
        Container.Bind<Grid>().To<Grid>().AsSingle();
    }
}