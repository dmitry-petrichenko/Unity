using System.Collections;
using System.Collections.Generic;
using NSMapInfoController;
using NSMapViewController;
using UnityEngine;

public class GameController : MonoBehaviour {

	private MapInfoController _mapInfoController;
	private MapViewController _mapViewController;
	
	// Use this for initialization
	void Start () {
		
		_mapInfoController = new MapInfoController();
		_mapInfoController.Initialize();
		ServiceLocator.InitializeMapInfoController(_mapInfoController);
		
		_mapViewController = new MapViewController();
		_mapViewController.Initialize();
		ServiceLocator.InitializeMapViewController(_mapViewController);
		
		_mapViewController.UpdateCurrentPosition(new IntVector2(4, 4));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
