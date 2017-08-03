using System.Collections;
using System.Collections.Generic;
using NSGraphics;
using NSMapInfoController;
using NSMapViewController;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject Plane, Cube, Empty;
	
	private MapInfoController _mapInfoController;
	private MapViewController _mapViewController;
	private GraphicsController _graphicsController;
	
	// Use this for initialization
	void Start () {
		
		_graphicsController = new GraphicsController();
		_graphicsController.Initialize(gameObject, Plane, Cube, Empty);
		ServiceLocator.InitializeGraphicsController(_graphicsController);
		
		_mapInfoController = new MapInfoController();
		_mapInfoController.Initialize();
		ServiceLocator.InitializeMapInfoController(_mapInfoController);
		
		_mapViewController = new MapViewController();
		_mapViewController.Initialize();
		ServiceLocator.InitializeMapViewController(_mapViewController);
		
		_mapViewController.UpdateCurrentPosition(new IntVector2(4, 4));
		
		ServiceLocator.GetGraphicsController().InitializeCube(new IntVector2(2, 0));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
