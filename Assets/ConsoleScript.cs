using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleScript : MonoBehaviour {
	public Text ConsoleDisp;
	float c1;
	int x = 300;
	private float TimeElapsed = 0;
	private bool IsClicked = false;


	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		//IsClicked = false;
		TimeElapsed += Time.deltaTime;
		if (TimeElapsed > 2.0f) {
			c1 = gameObject.GetComponent<Text> ().color.a;
			c1 = c1 - 0.02f;
			gameObject.GetComponent<Text> ().color = new Color (0, 0, 0, c1);
		}
	}

	public void OnClick(){
		IsClicked = true;
		gameObject.GetComponent<Text> ().color = new Color (0, 0, 0, 1);
		TimeElapsed = 0f;
	}
}
