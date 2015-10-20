using UnityEngine;
using System.Collections;

public class RayDraw : MonoBehaviour {

	public float rayDistance = 5;
	public GameObject guitar;
	private Animator guitanim;
	private float pitch1 = 1;
	public Transform guitend;

	public GameObject music;
	public GameObject ambient;

	public GameObject part;

	private bool doCastRay = true;

	// Use this for initialization
	void Start () { 

		Cursor.visible = false;
		guitanim = guitar.GetComponent<Animator> ();


	}
	
	// Update is called once per frame
	void Update () {
		if (doCastRay == true) {
			castRay();
		}
	}
		
	void castRay() {
		RaycastHit hitInfo;
		//if something is rayDistance away from this object from the fronte
		if (Input.GetKeyDown (KeyCode.Mouse0) || Input.GetKeyDown (KeyCode.LeftCommand)){
			Instantiate(part,guitend.position,guitend.rotation);
			guitar.GetComponent<AudioSource>().Play ();
			guitar.GetComponent<AudioSource>().pitch = pitch1;
			pitch1 = pitch1 + 0.05f;
			if (pitch1 >= 1.20f){
				pitch1 = 1;}
			guitanim.Play("Shoot");

			//don´t allow raycast for 2 seconds
			doCastRay = false;
			Invoke("turnRaycastOn", 0.5f);

			if (Physics.Raycast(transform.position, transform.forward, out hitInfo,rayDistance)) {
				Debug.Log ("HIT:" + hitInfo.collider.name);
				if (hitInfo.collider.gameObject.tag == "Enemy"){
					hitInfo.collider.gameObject.GetComponent<Animator>().SetInteger("State",2);
					hitInfo.collider.gameObject.GetComponent<AudioSource>().volume = 0.4f;
					Destroy(music);
					Destroy(ambient);
					//Destroy(hitInfo.collider.gameObject);
				}
			}
		}
	}
	void turnRaycastOn() {
		doCastRay = true;
	}
	void OnDrawGizmos() {
		Gizmos.color = Color.red;
		Gizmos.DrawRay (transform.position, transform.forward * rayDistance);
	}
}