using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defenseCreator : MonoBehaviour {

	public GameObject tower;
	public GameObject moat;
	public GameObject moatChild;
	public GameObject sand;

	public MoneyManager moneyManager;

	private GameObject nextType;
	public enum DefenseType {
		Turret,
		Moat,
		Sand
	}
	private DefenseType nextDefType;
	private float lastX;
	private float lastY;
	private Vector3 lastPos;

	private float sepTolerance = .2f;
	private bool dragMode;
	private GameObject dragParent;
	// Use this for initialization
	void Start () {
		nextType = tower;
	}
	
	// Update is called once per frame
	void Update () {



		var mousePos = getMousePos ();

		if (Input.GetMouseButtonDown (0)) {
			if (!CheckAndDeductMoney ()) {
				print ("out of money brah you broke");
				return; 

			} 
			if (nextType == tower) {
				var newtower = Instantiate (tower, mousePos, Quaternion.identity);
				newtower.transform.parent = gameObject.transform;
				dragMode = false;	
			} else if (nextType == moat) {
				var newMoat = Instantiate (moat, mousePos, Quaternion.identity);
				newMoat.transform.parent = gameObject.transform;
				dragParent = newMoat;
				dragMode = true;
			}
		}
		if (Input.GetMouseButtonUp (0)){
			dragMode = false;
		}

		if (dragMode && ((Mathf.Abs (mousePos.x - lastPos.x) > sepTolerance) || (Mathf.Abs (mousePos.y - lastPos.y) > sepTolerance))) {
			if (!CheckAndDeductMoney ()) {
				print ("out of money brah you broke");
				dragMode = false;
				return; 

			} 
			var newMoatChild = Instantiate (moatChild, mousePos, Quaternion.identity);
			newMoatChild.transform.parent = dragParent.transform;
			lastPos = getMousePos();
		}
			
	}

	public void SetNextTower(){
		nextType = tower;
		nextDefType = DefenseType.Turret;
	}
		
	public void SetNextMoat(){
		nextType = moat;
		nextDefType = DefenseType.Moat;
	}
	public void SetNextSand(){
		nextType = sand;
		nextDefType = DefenseType.Sand;
	}

	public bool CheckAndDeductMoney() {
		switch (nextDefType) {
		case DefenseType.Moat:
			return moneyManager.BuyMoat ();
		case DefenseType.Sand:
			return moneyManager.BuySand ();
		case DefenseType.Turret:
			return moneyManager.BuyTurret ();
		}
		return false;
	}
		
	private Vector3 getMousePos(){
		var mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		var flatPos = new Vector3 (mousePos.x, mousePos.y);
		flatPos.z = 0;
		return flatPos;
	}
}
