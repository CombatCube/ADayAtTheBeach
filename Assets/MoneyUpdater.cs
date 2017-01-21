using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUpdater : MonoBehaviour {
	public int Money = 0;
	public int Reward = 0;
	public Text MoneyText;
	public void increment(){
		Money++;
	}
	//Money = increment(Money);
		

	// Use this for initialization
	void Start () {
		MoneyText = gameObject.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		Money = Money + Reward;
		MoneyText.text = "Money: " + Money;
	}
}
