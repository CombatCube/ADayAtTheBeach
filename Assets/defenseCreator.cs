using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defenseCreator : MonoBehaviour {

	public GameObject tower;
	public GameObject moat;
	private GameObject nextType;
	private float lastX;
	private float lastY;
	private float sepTolerance = .05f;
	// Use this for initialization
	void Start () {
		nextType = tower;
	}
	
	// Update is called once per frame
	void Update () {

		var mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		var objectPos = new Vector3 (mousePos.x, mousePos.y);

		objectPos.z = 0;

		if (Input.GetMouseButtonDown (0) && nextType == tower) {
			var newObject = Instantiate (tower, objectPos, Quaternion.identity);
			newObject.transform.parent = gameObject.transform;
		} else if (Input.GetMouseButton (0) && nextType == moat && 
			(mousePos.x + sepTolerance < lastX || mousePos.x - sepTolerance > lastX) &&
			(mousePos.y + sepTolerance < lastY || mousePos.y - sepTolerance > lastY)) {
			var newObject = Instantiate (moat, objectPos, Quaternion.identity);
			newObject.transform.parent = gameObject.transform;
			lastX = mousePos.x;
			lastY = mousePos.y;
		}

	}

	public void SetNextSandTower(){
		nextType = tower;
	}

	public void SetNextMoat(){
		nextType = moat;
	}
}
