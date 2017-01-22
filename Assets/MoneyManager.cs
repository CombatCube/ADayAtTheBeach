using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour {
	public int Money;
	public int Reward;
	public int MoatCost;
	public int SandCost;
	public int TurretCost;
	public Dictionary<defenseCreator.DefenseType, int> DefenseCosts = new Dictionary<defenseCreator.DefenseType, int>();
	public ConsoleScript ConsoleText;
	// Use this for initialization
	void Start () {
		DefenseCosts.Add (defenseCreator.DefenseType.Moat, MoatCost);
		DefenseCosts.Add (defenseCreator.DefenseType.Sand, SandCost);
		DefenseCosts.Add (defenseCreator.DefenseType.Tower, TurretCost);
	}

	// Update is called once per frame
	void Update () {

	}

	 public bool BuyTurret(){
		if ((Money - TurretCost) >= 0){
			Money = Money - TurretCost;
			ConsoleText.GetComponent<Text> ().text = "You've bought a turret!";
			print("You've bought a tower!");
			return true;
		}
		else {
			print("You don't have enough money!");
			ConsoleText.GetComponent<Text> ().text = "You don't have enough money!";
			return false;
		}
	}

	public bool BuySand(){
		if ((Money - SandCost) >= 0){
			Money = Money - SandCost;
			print("You've bought sand!");
			ConsoleText.GetComponent<Text> ().text = "You've bought sand!";
			return true;
		}
		else {
			print("You don't have enough money!");
			ConsoleText.GetComponent<Text> ().text = "You don't have enough money!";
			return false;
		}
	}

	public bool BuyMoat() {
		if (Money - MoatCost >= 0) {
			Money -= MoatCost;
			print("You've bought a moat!");
			ConsoleText.GetComponent<Text> ().text = "You've bought a moat!";
			return true;
		} else {
			print("You don't have enough money!");
			ConsoleText.GetComponent<Text> ().text = "You don't have enough money!";
			return false;
		}
	}
		
	public void GainMoney( int amount ) {
		Money += amount;
		ConsoleText.GetComponent<Text> ().text = "Gained " + amount.ToString() + " grains of sand!";
		ConsoleText.OnClick ();

	}
	/*
	 public void BuyTower(){
		if ((Money - TowerCost) >= 0){
			Money = Money - TowerCost;
			ConsoleText.GetComponent<Text> ().text += "\nYou've bought a tower!";
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
	}*/ 
}
