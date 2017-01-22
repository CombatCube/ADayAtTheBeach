using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour {
	public int Money;
	public int Reward;
	public int SandCost;
	public int TowerCost;
	public ConsoleScript ConsoleText;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {

	}

	 public void BuyTower(){
		if ((Money - TowerCost) >= 0){
			Money = Money - TowerCost;
			ConsoleText.GetComponent<Text> ().text = "You've bought a tower!";
			print("You've bought a tower!");

		}
		else {
			
			print("You don't have enough money!");
			ConsoleText.GetComponent<Text> ().text = "You don't have enough money!";
		}
	}

	public void BuySand(){
		if ((Money - SandCost) >= 0){
			Money = Money - SandCost;
			print("You've bought sand!");
			ConsoleText.GetComponent<Text> ().text = "You've bought sand!";
		}
		else {
			print("You don't have enough money!");
			ConsoleText.GetComponent<Text> ().text = "You don't have enough money!";
		}
	}
}
