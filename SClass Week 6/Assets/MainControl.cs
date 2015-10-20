using UnityEngine;
using System.Collections;

public class MainControl : MonoBehaviour {

	private Animator SonicControl;

	// Use this for initialization
	void Start () {	

		SonicControl = GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.D)){
			SonicControl.SetInteger("State",1);
		}else{
			SonicControl.SetInteger("State",2);
		}
	
	}
}
