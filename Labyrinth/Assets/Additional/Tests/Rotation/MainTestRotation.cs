using System;
using UnityEngine;
using ZScripts;
using ZScripts.Units.Rotation;

public class MainTestRotation : MonoBehaviour
{
	private OneUnitRotationController _oneUnitRotationController;
	// Use this for initialization
	void Start () {
		_oneUnitRotationController = new OneUnitRotationController();
		//_oneUnitRotationController.Initialize(gameObject);
	}
	
	public void RotateTo(string param)
	{
		string [] parameters = param.Split(new Char [] {','});
		_oneUnitRotationController.Rotate(new IntVector2(Int32.Parse(parameters[0]), Int32.Parse(parameters[1])),
			new IntVector2(Int32.Parse(parameters[2]), Int32.Parse(parameters[3])));
		
		/*
		_oneUnitRotationController.Rotate(new IntVector2(Int32.Parse(parameters[1]), Int32.Parse(parameters[0])),
			new IntVector2(Int32.Parse(parameters[3]), Int32.Parse(parameters[2])));
			*/
	}
}
