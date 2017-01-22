using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandcastleIncome : MonoBehaviour {

	public MoneyManager moneyManager; 
	public Health sandcastleHealth; // put self into here
	private float incomeIntervalSeconds = 5.0f;
	// Use this for initialization
	void Start () {
		StartCoroutine (healthToWealth());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator healthToWealth() {
		while (true) {
			yield return new WaitForSeconds (incomeIntervalSeconds);
			moneyManager.GainMoney ((int)sandcastleHealth.currentHealth);
		}
	}
}

