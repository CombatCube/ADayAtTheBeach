using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDelete : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var cameraDist = gameObject.transform.position - Camera.main.transform.position;
		cameraDist.z = 0;
		if (cameraDist.magnitude > 10) {
			print (gameObject.transform.position);
			print (Camera.main.transform.position);
			print ("self delete" + gameObject.ToString());
			DestroyObject (this.gameObject);
		}
	}
}
