using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	public int currentHealth = 100;
	public int totalHealth = 100;
	public TOWER_TYPE towerType;

	public enum TOWER_TYPE {
		SAND_TOWER,
		MOAT,
		WALL
	}

	private readonly string[] TOWER_SPRITES = {"sandcastle", "moat", "wall"};

	// Use this for initialization
	void Start () {
		Sprite towerSprite = Resources.Load<Sprite> (TOWER_SPRITES[(int)towerType]);
		GetComponent<SpriteRenderer> ().sprite = towerSprite;
	}
	
	// Update is called once per frame
	void Update () {
		//TODO remove this once debugging is done
		Sprite towerSprite = Resources.Load<Sprite> (TOWER_SPRITES[(int)towerType]);
		GetComponent<SpriteRenderer> ().sprite = towerSprite;
	}
}
