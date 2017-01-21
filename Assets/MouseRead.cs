using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRead : MonoBehaviour {

	public GameObject cratePink;
	public GameObject sandToMake;
	// Use this for initialization
	public GameObject sandObject;
	public GameObject towerObject;
	public enum SandCreateMode {
		createSand,
		createTower
	}
	public SandCreateMode createMode = SandCreateMode.createSand;

	public void setSandMode() {
		createMode = SandCreateMode.createSand;
		sandToMake = sandObject;
	}

	public void setTowerMode() {
		createMode = SandCreateMode.createTower;
		sandToMake = towerObject;
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.touchCount > 0 ) {
			var touchPos = Input.GetTouch (0).position;
			var movePos = Camera.main.ScreenToWorldPoint (touchPos);
			var newSand = Instantiate (sandToMake);
			movePos.z = 0;
			newSand.transform.position = movePos;
		} else if (Input.GetMouseButtonDown (0) || (createMode == SandCreateMode.createSand && Input.GetMouseButton( 0 ) )) {
			var mousePos = Input.mousePosition;
			var movePos = Camera.main.ScreenToWorldPoint (mousePos);
			var newSand = Instantiate (sandToMake);
			movePos.z = 0;
			newSand.transform.position = movePos;
			print (movePos);
		}
	}
}
