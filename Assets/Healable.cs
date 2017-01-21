using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healable : MonoBehaviour {

	public float healthPerFrame;
	public Health health;

	void OnMouseOver() {
		if (Input.GetMouseButton (0) && health.currentHealth <= health.maxHealth) {
			health.currentHealth += healthPerFrame;
		}
	}
}
