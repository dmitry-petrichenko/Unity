using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject unit = GameObject.FindGameObjectsWithTag("Unit").FirstOrDefault();
		unit.transform.Rotate(0, 180, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
