using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class defenseCreator : MonoBehaviour, IPointerUpHandler, IPointerDownHandler{

    public GameObject tower;
    public GameObject moat;
    public GameObject moatChild;
    public GameObject sand;
    public GameObject sandChild;

    public MoneyManager moneyManager;

    public enum DefenseType {
        Turret,
        Moat,
        MoatChild,
        Sand,
        SandChild
    }

    private DefenseType nextDefType = DefenseType.Turret;
    private Vector3 lastPos;

    private float moatSepTolerance;
    private float sandSepTolerance;
    private float towTolerance;

    private bool dragMode;
    private bool canCreate = false;

    private GameObject activeParent;
    public ConsoleScript ConsoleText;

    // Use this for initialization
    void Start() {
        moatSepTolerance = moatChild.GetComponent<SpriteRenderer>().sprite.bounds.extents.x;
        sandSepTolerance = sandChild.GetComponent<SpriteRenderer>().sprite.bounds.extents.x;
        towTolerance = tower.GetComponent<SpriteRenderer>().sprite.bounds.extents.x * 2;
    }

    // Update is called once per frame
    void Update() {

        
        // dragmode true
        if (dragMode && (nextDefType == DefenseType.MoatChild || nextDefType == DefenseType.SandChild)) {

            // deduct money or turn off drag mode, stop creation, and escape.
            if (!CheckMoney()) {
                ConsoleText.GetComponent<Text>().text = "You don't have enough money!";
                ConsoleText.OnClick();
                dragMode = false;
                return;
            }
            switch (nextDefType)
            {
                case DefenseType.MoatChild: 
                    var newMoatChild = Instantiate(moatChild, GetMousePos(), Quaternion.identity);
                    newMoatChild.transform.parent = activeParent.transform; break;
                case DefenseType.SandChild:
                    var newSandChild = Instantiate(sandChild, GetMousePos(), Quaternion.identity); 
                    newSandChild.transform.parent = activeParent.transform; break;
            }
            ConsoleText.OnClick();
        }
	}

   /* private bool WillOverlap(DefenseType type){
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
    }
    */

    public void OnPointerDown(PointerEventData eventData)
    {
        //escape if you can't create
        if (!canCreate) {
			//print ("can't create on down");
			return;
		}

		//deduct money or escape
		if (!CheckMoney ()) {
			 //print("You don't have enough money!");
			return; 
		} 

		//if turret 
		if (nextDefType == DefenseType.Turret 
            //&& !WillOverlap(DefenseType.Tower)
            ) {

			//make turret, set dragmode false, reset last place
			changeText(DefenseType.Turret);
			MakeActiveParent(DefenseType.Turret);
			canCreate = false;
			dragMode = false;

			// if moat
		} else if (nextDefType == DefenseType.Moat) {

			//make moat, set new moat as moatParent, set dragmode true
			changeText(DefenseType.Moat);
			MakeActiveParent(DefenseType.Moat);
			canCreate = false;
			dragMode = true;
            nextDefType = DefenseType.MoatChild;

			//if sand
		} else if (nextDefType == DefenseType.Sand) {

			//make sand, set new sand as activeParent, set dragmode true
			changeText(DefenseType.Sand);
			MakeActiveParent(DefenseType.Sand);
			canCreate = false;
			dragMode = true;
            nextDefType = DefenseType.SandChild;
        }
	}

   /*
    * make defense parent of correct type
    */
    private void MakeActiveParent(DefenseType type)
    {
        GameObject buildType = tower;
        switch (type)
        {
            case DefenseType.Turret:
                buildType = tower; break;
            case DefenseType.Moat:
                buildType = moat; break;
            case DefenseType.Sand:
                buildType = sand; break;
        }

        activeParent = Instantiate(buildType, GetMousePos(), Quaternion.identity);
        activeParent.transform.parent = gameObject.transform;
    }



    public void OnPointerUp(PointerEventData eventData){
        //dragmode false, can't create
        dragMode = false;
	}

   /*
    * deduct if you can buy next def type
    */
    public bool CheckMoney()
    {
        switch (nextDefType)
        {
            case DefenseType.Moat:
                return moneyManager.BuyMoat();
            case DefenseType.MoatChild:
                return moneyManager.BuyMoat();
            case DefenseType.Sand:
                return moneyManager.BuySand();
            case DefenseType.SandChild:
                return moneyManager.BuySand();
            case DefenseType.Turret:
                return moneyManager.BuyTurret();
        }
        return false;
    }

    /*
	 * return mouse position 
	 */
    private Vector3 GetMousePos(){
		var mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		var flatPos = new Vector3 (mousePos.x, mousePos.y);
		flatPos.z = 0;
		return flatPos;
	}

    /*
 * change text to correct type
 */
    private void changeText(DefenseType type) {
        Text text;
        switch (type)
        {
        case DefenseType.Turret:
            ConsoleText.GetComponent<Text>().text = "You've bought a turret!"; break;
        case DefenseType.Moat:
            ConsoleText.GetComponent<Text>().text = "You've bought a moat!"; break;
        case DefenseType.Sand:
                 ConsoleText.GetComponent<Text>().text = "You've bought sand!"; 
                break;
        }
        ConsoleText.OnClick();
    }

    /*
	 * called by buttons, set next defence type
	 */
    public void SetNextTower(){
		nextDefType = DefenseType.Turret;
		canCreate = true;
	}

	public void SetNextMoat(){
		nextDefType = DefenseType.Moat;
		canCreate = true;
	}
	public void SetNextSand(){
		nextDefType = DefenseType.Sand;
		canCreate = true;
	}
}
