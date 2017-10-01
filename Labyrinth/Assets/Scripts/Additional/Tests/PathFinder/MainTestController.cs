using Labyrinth;
using Labyrinth.Additional.Tests;
using Labyrinth.Map;
using Labyrinth.Settings;
using Labyrinth.Units;
using Units.PathFinder;
using UnityEngine;
using MapViewController = Labyrinth.Additional.Tests.MapViewController;

public class MainTestController : MonoBehaviour
{
	public GameObject _mainScene, _empty, _busy, _start, _end, _way, _minor, _close, _open;
	
	private IMapInfoController _mapInfoController;
	private MapControllerTest _mapController;
	private MapViewController _mapViewController;
	private SettingsList _settingsList;
	private MapGraphicsList _mapGraphicsList;
	private PathFinderController _pathFinderController;

	void Start()
	{
		_mapGraphicsList = new MapGraphicsList();
		_mapGraphicsList.Initialize(gameObject, _busy, _busy, _busy, _busy);
		
		_settingsList = new SettingsList();
		_settingsList.Initialize(_mapGraphicsList, _empty);
		
		ServiceLocator.InitializeSettings(_settingsList);
		
		MapInfoController mapInfoController = new MapInfoController();
		mapInfoController.Initialize();
		_mapInfoController = mapInfoController;
		MapServiceLocator.InitializeMapInfoController(_mapInfoController);

		_mapViewController = new MapViewController();
		_mapViewController.Initialize(_mainScene, _empty, _busy, _start, _end, _way, _minor, _close, _open);
		
		_pathFinderController = new PathFinderController();
		_pathFinderController.Initialize();
		UnitsServiceLocator.InitializePathFinder(_pathFinderController);

		_mapController = new MapControllerTest();
		_mapController.Initialize(_mapInfoController, _mapViewController);

	}

	public void SetPath()
	{
		_mapController.SetPath();
	}

	public void ChangeMode()
	{
		_mapController.ChangeMode();
	}
}
