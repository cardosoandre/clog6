using UnityEngine;
using System.Collections;

public class RayShooter : MonoBehaviour {

	public float rayDistance = 5;

	// Use this for initialization
	void Start () { 

	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hitInfo;
		//if something is rayDistance away from this object from the fronte
		if (Physics.Raycast(transform.position, transform.forward, out hitInfo, rayDistance)) {
			Debug.Log ("you've hit the thing names:" + hitInfo.collider.name);
		}

	
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.red;
		Gizmos.DrawRay (transform.position, transform.forward * rayDistance);
}
}