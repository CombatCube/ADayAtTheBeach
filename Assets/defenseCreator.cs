using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class defenseCreator : MonoBehaviour {

	public GameObject tower;
	public GameObject moat;
	public GameObject moatChild;
	public GameObject sand;
	public GameObject sandChild;

	public MoneyManager moneyManager;

	public enum DefenseType {
		Turret,
		Moat,
		Sand
	}
	private DefenseType nextDefType = DefenseType.Turret;
	private bool canCreate = false;
	private float lastX;
	private float lastY;
	private Vector3 lastPos;

	private float sepTolerance;
	private float towTolerance;
	private bool dragMode;
	private GameObject dragParent;
	// Use this for initialization
	void Start () {
		sepTolerance = moatChild.GetComponent<SpriteRenderer>().sprite.bounds.extents.x;
		print (sepTolerance);
		towTolerance = tower.GetComponent<SpriteRenderer> ().sprite.bounds.extents.x * 2;
		print (towTolerance);
	}

	// Update is called once per frame
	void Update () {

		var mousePos = getMousePos ();
		if (Input.GetMouseButtonDown (0)) {
			print ("mousedown detected");
			print (nextDefType);
			if (!canCreate) {
				print ("can't create on down");
				return;
			}
			if (EventSystem.current.IsPointerOverGameObject()) {
				// ignore mouse when over gui elements.
				print ("over gui down");
				return;
			}
			if (!CheckAndDeductMoney ()) {
				print ("out of money brah you broke");
				return; 

			} 
			if (nextDefType == DefenseType.Turret && Vector3.Distance (mousePos, lastPos) > towTolerance) {
				var newtower = Instantiate (tower, mousePos, Quaternion.identity);
				newtower.transform.parent = gameObject.transform;
				dragMode = false;
				lastPos = getMousePos ();
			} else if (nextDefType == DefenseType.Moat) {
				var newMoat = Instantiate (moat, mousePos, Quaternion.identity);
				newMoat.transform.parent = gameObject.transform;
				dragParent = newMoat;
				dragMode = true;
			} else if (nextDefType == DefenseType.Sand) {
				var newSand = Instantiate (sand, mousePos, Quaternion.identity);
				newSand.transform.parent = gameObject.transform;
				dragParent = newSand;
				dragMode = true;
			}
		}
		if (Input.GetMouseButtonUp (0)){
			if (EventSystem.current.IsPointerOverGameObject()) {
				// ignore mouse when over gui elements.
				print ("over gui up");
				return;
			}
			dragMode = false;
			canCreate = false;
			print ("canCreate set false on mouseup");
		}

		if (dragMode && Vector3.Distance(mousePos, lastPos) > sepTolerance) {

			if (!CheckAndDeductMoney ()) {
				print ("out of money brah you broke");
				dragMode = false;
				print ("canCreate false on drag end");
				canCreate = false;
				return; 
			}
			if (nextDefType == DefenseType.Moat) {
				var newMoatChild = Instantiate (moatChild, mousePos, Quaternion.identity);
				newMoatChild.transform.parent = dragParent.transform;
				lastPos = getMousePos ();
			} else if (nextDefType == DefenseType.Sand) {
				var newSandChild = Instantiate (sandChild, mousePos, Quaternion.identity);
				newSandChild.transform.parent = dragParent.transform;
				lastPos = getMousePos ();
			}
		}
			
	}

	public void SetNextTower(){
		nextDefType = DefenseType.Turret;
		canCreate = true;
		print ("canCreate is true");
	}
		
	public void SetNextMoat(){
		nextDefType = DefenseType.Moat;
		canCreate = true;
	}
	public void SetNextSand(){
		nextDefType = DefenseType.Sand;
		canCreate = true;
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

	void OnMouseDown() {
		print ("mouseDown");
	}
	void OnPointerDown() {
		print ("pointerDown");
	}
}
