using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuildSandOnClick : MonoBehaviour {

	public Button sandButton;
	public MouseRead mouseReader;
	public GameObject sandObject;
	void onClick() {
		print ("Setting to sand");
		mouseReader.sandToMake = sandObject;
	}
	// Use this for initialization
	void Start () {
		Button btn = sandButton.GetComponent<Button> ();
		btn.onClick.AddListener (onClick);
	}

	// Update is called once per frame
	void Update () {

	}
}
