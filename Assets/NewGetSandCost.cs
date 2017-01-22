using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewGetSandCost : MonoBehaviour {
	public MoneyManager Manager;
	public Text SandCostText;

	// Use this for initialization
	void Start () {
		SandCostText = gameObject.GetComponent<Text> ();
	}

	// Update is called once per frame
	void Update () {
		SandCostText.text = " Build \n Sand \n" + Manager.SandCost + " Sand";

	}
}
