using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using NSCameraController;
using NSGraphics;
using NSMapInfoController;
using NSMapViewController;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject Plane, Cube, Square, Empty;
	public Camera _camera;
	
	private MapInfoController _mapInfoController;
	private MapViewController _mapViewController;
	private GraphicsController _graphicsController;
	private CameraController _cameraController;

	private int g;
	
	// Use this for initialization
	void Start () {
		_cameraController = new CameraController();
		_cameraController.Initialize(_camera);
		ServiceLocator.InitializeCameraController(_cameraController);
		
		_graphicsController = new GraphicsController();
		_graphicsController.Initialize(gameObject, Plane, Cube, Square, Empty);
		ServiceLocator.InitializeGraphicsController(_graphicsController);
		
		_mapInfoController = new MapInfoController();
		_mapInfoController.Initialize();
		ServiceLocator.InitializeMapInfoController(_mapInfoController);
		
		_mapViewController = new MapViewController();
		_mapViewController.Initialize();
		ServiceLocator.InitializeMapViewController(_mapViewController);
		
		_mapViewController.UpdateCurrentPosition(new IntVector2(0, 0));
		_cameraController.UpdateCurrentPosition(new IntVector2(0, 0));
		g = 0;
		InvokeRepeating("cl", 1f, 1f);

	}

	private void cl()
	{
		g++;
		_mapViewController.UpdateCurrentPosition(new IntVector2(g, 0));
		_cameraController.UpdateCurrentPosition(new IntVector2(g, 0));
		Debug.Log(g);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
