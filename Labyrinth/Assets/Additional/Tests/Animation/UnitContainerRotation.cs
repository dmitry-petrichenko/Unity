using UnityEngine;

public class UnitContainerRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Rotate(Vector3.up * Time.deltaTime * 25, Space.Self);
	}
}
