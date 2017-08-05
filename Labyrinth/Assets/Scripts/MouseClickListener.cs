using UnityEngine;

public class MouseClickListener : MonoBehaviour {

	void Update () {
		if( Input.GetMouseButtonDown(0) )
        {
            Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
            RaycastHit hit;
            
            if( Physics.Raycast( ray, out hit, 100 ) )
            {
                Debug.Log( hit.transform.gameObject.transform.parent.gameObject.transform.position.x + " " +
                hit.transform.gameObject.transform.parent.gameObject.transform.position.z);
            }
        }
	}
}
