using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuildTowerOnClick : MonoBehaviour {

	public Button towerButton;
	public MouseRead mouseReader;
	public GameObject towerObject;
	public void onClick() {
		print ("Setting to tower");
		mouseReader.sandToMake = towerObject;
	}

	// Use this for initialization
	void Start () {
		Button btn = towerButton.GetComponent<Button> ();
		btn.onClick.AddListener (onClick);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
