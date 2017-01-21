using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerClick : MonoBehaviour {
	bool isClicked = false;

	void OnMouseDown() {
		isClicked = !isClicked;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isClicked) {
			gameObject.GetComponent<SpriteRenderer> ().color = Color.black;
		} else {
			gameObject.GetComponent<SpriteRenderer> ().color = Color.cyan;
		}
	}
}
