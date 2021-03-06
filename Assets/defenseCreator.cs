using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class defenseCreator : MonoBehaviour,
    IPointerClickHandler,
    IPointerDownHandler,
    IPointerUpHandler,
    IBeginDragHandler,
    IDragHandler,
    IEndDragHandler
{

	public GameObject tower;
	public GameObject moat;
	public GameObject moatChild;
	public GameObject sand;
	public GameObject sandChild;
    public float minDist = 0.01f;

    public MoneyManager moneyManager;

	public enum DefenseType {
        None,
        Tower,
		Moat,
		Sand
	}
    public DefenseType CurrentType = DefenseType.None;
    public GameObject Field;
    private GameObject lastChild;
    private GameObject newChildObject;
    private GameObject activeParent;
	public ConsoleScript ConsoleText;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void SetNextMoat(){
		CurrentType = DefenseType.Moat;
        newChildObject = moatChild;
	}

    public void SetNextTower()
    {
        CurrentType = DefenseType.Tower;
    }

    public void SetNextSand()
    {
        CurrentType = DefenseType.Sand;
        newChildObject = sandChild;
    }

    public bool CheckAndDeductMoney() {
		switch (CurrentType) {
		case DefenseType.Moat:
			return moneyManager.BuyMoat ();
		case DefenseType.Sand:
			return moneyManager.BuySand ();
		case DefenseType.Tower:
			return moneyManager.BuyTurret ();
		}
		return false;
	}

    public void OnPointerClick(PointerEventData eventData)
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }


    public void OnPointerUp(PointerEventData eventData)
    {
        print("Clicked at " + eventData.pointerPressRaycast.worldPosition);
        if (CurrentType == DefenseType.Tower)
        {
			if (CheckAndDeductMoney ()) {
				Instantiate (tower, eventData.pointerCurrentRaycast.worldPosition, Quaternion.Euler (Vector3.zero), transform);
			} 
        }
        CurrentType = DefenseType.None;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        switch (CurrentType)
        {
            case DefenseType.Moat:
                activeParent = Instantiate(moat, transform);
                activeParent.transform.position = eventData.pointerCurrentRaycast.worldPosition;
                spawnChild(eventData.pointerCurrentRaycast.worldPosition);
                break;
            case DefenseType.Sand:
                activeParent = Instantiate(sand, transform);
                activeParent.transform.position = eventData.pointerCurrentRaycast.worldPosition;
                spawnChild(eventData.pointerCurrentRaycast.worldPosition);
                break;
            default:
                break;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject == gameObject
            && (CurrentType == DefenseType.Moat || CurrentType == DefenseType.Sand))
        {
            Vector2 nextPos = lastChild.transform.position - eventData.pointerCurrentRaycast.worldPosition;
            if (nextPos.magnitude > minDist)
            {
                spawnChild(eventData.pointerCurrentRaycast.worldPosition);
            }
        }
        else if (eventData.pointerCurrentRaycast.gameObject != gameObject)
        {
            print("Dragged onto: " + eventData.pointerCurrentRaycast.gameObject);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        lastChild = null;
        activeParent = null;
    }

    private void spawnChild(Vector3 pos)
    {
        if (CheckAndDeductMoney())
        {
            lastChild = Instantiate(newChildObject, pos, Quaternion.identity, activeParent.transform);
        }
    }
}
