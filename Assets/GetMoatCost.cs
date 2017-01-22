using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetMoatCost : MonoBehaviour {
	
	//public int MoatCost;
	public MoneyManager Manager;
	public Text MoatCostText;

	// Use this for initialization
	void Start () {
		MoatCostText = gameObject.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		MoatCostText.text = " Build \n Moat \n" + Manager.MoatCost + " Sand";
	}
}
