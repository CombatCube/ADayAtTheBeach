using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerClick : MonoBehaviour {
	bool isClicked = false;
	Color c1 = Color.cyan;
	void OnMouseDown() {
		isClicked = !isClicked;
	}
	// Use this for initialization
	void Start () {
		c1.a = c1.a - 0.25f;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isClicked) {
			gameObject.GetComponent<SpriteRenderer> ().color = c1;
		} else {
			gameObject.GetComponent<SpriteRenderer> ().color = Color.cyan;
		}
	}
}
