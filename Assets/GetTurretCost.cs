using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTurretCost : MonoBehaviour {
	public MoneyManager Manager;
	public Text TurretCostText;

	// Use this for initialization
	void Start () {
		TurretCostText = gameObject.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		TurretCostText.text = " Build \n Turret \n" + Manager.TurretCost + " Sand";
		
	}
}
