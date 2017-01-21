using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour {
	public int Money;
	public int Reward;
	public const int MoatCost = 1;
	public const int SandCost = 5;
	public const int TurretCost = 10;
	public Dictionary<defenseCreator.DefenseType, int> DefenseCosts = new Dictionary<defenseCreator.DefenseType, int>();
	// Use this for initialization
	void Start () {
		DefenseCosts.Add (defenseCreator.DefenseType.Moat, MoatCost);
		DefenseCosts.Add (defenseCreator.DefenseType.Sand, MoneyManager.SandCost);
		DefenseCosts.Add (defenseCreator.DefenseType.Turret, MoneyManager.TurretCost);
	}

	// Update is called once per frame
	void Update () {

	}

	 public bool BuyTurret(){
		if ((Money - TurretCost) >= 0){
			Money = Money - TurretCost;
			return true;
		}
		else {
			return false;
		}
	}

	public bool BuySand(){
		if ((Money - SandCost) >= 0){
			Money = Money - SandCost;
			return true;
		}
		else {
			return false;
		}
	}

	public bool BuyMoat() {
		if (Money - MoatCost >= 0) {
			Money -= MoatCost;
			return true;
		} else {
			return false;
		}
	}
}
