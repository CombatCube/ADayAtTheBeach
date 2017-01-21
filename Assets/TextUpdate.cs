using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdate : MonoBehaviour {
	public int Day = 0;
	public Text DayText;
	// Use this for initialization
	void Start () {
		DayText = gameObject.GetComponent<Text> ();
	}

	
	// Update is called once per frame
	void Update () {
		DayText.text = "Day: " + Day;
		//Day = Day + 1;

	}
}
