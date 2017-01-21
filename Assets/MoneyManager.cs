using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour {
	public int Money;
	public int Reward;
	public int SandCost = 5;
	public int TowerCost = 10;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {

	}

	 public void BuyTower(){
		if ((Money - TowerCost) >= 0){
			Money = Money - TowerCost;
			print("You've bought a tower!");
		}
		else {
			print("You don't have enough money!");
		}
	}

	public void BuySand(){
		if ((Money - SandCost) >= 0){
			Money = Money - SandCost;
			print("You've bought sand!");
		}
		else {
			print("You don't have enough money!");
		}
	}
}
