using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCastle : MonoBehaviour {

	public GameObject castle;
	public UnityStandardAssets.CrossPlatformInput.TouchPad touchPad;
	public TextMesh suh;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.touchCount > 0 ) {
			var touchPos = Input.GetTouch (0).position;
			var movePos = Camera.main.ScreenToWorldPoint (touchPos);
			var curPos = castle.transform.position;
			movePos.z = curPos.z;
			castle.transform.position = movePos;
			if (movePos.x - curPos.x > 0) {
				suh.text = "right";
			} else if ( movePos.x - curPos.x < 0 ) {
				suh.text = "left";
			}
		} else if (Input.GetMouseButtonDown (0) || Input.GetMouseButton( 0 )) {
			var mousePos = Input.mousePosition;
			var movePos = Camera.main.ScreenToWorldPoint (mousePos);
			var curPos = castle.transform.position;
			movePos.z = curPos.z;
			castle.transform.position = movePos;
			if (movePos.x - curPos.x > 0) {
				suh.text = "right";
			} else if ( movePos.x - curPos.x < 0 ) {
				suh.text = "left";
			}
		}
	}
}
