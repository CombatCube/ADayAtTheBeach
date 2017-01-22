using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyText : MonoBehaviour {
	public MoneyManager Manager;
	public Text MoneyDisp;
	// Use this for initialization
	void Start () {
		MoneyDisp = gameObject.GetComponent<Text> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		MoneyDisp.text = "Sand: " + Manager.Money + " grains";
	}
}
