using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardListener : MonoBehaviour {

    public defenseCreator defense;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Q))
        {
            defense.SetNextTower();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            defense.SetNextMoat();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            defense.SetNextSand();
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }
}
