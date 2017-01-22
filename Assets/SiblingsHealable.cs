using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiblingsHealable : MonoBehaviour {

	public float healthPerFrame;
	public Health health;

	void OnMouseOver() {
		if (Input.GetMouseButton (0)) {
			//Heal myself
			if (health.currentHealth <= health.maxHealth) {
				health.currentHealth += healthPerFrame;
			}

			//Heal my siblings
			Health[] siblings = gameObject.transform.parent.gameObject.GetComponentsInChildren<Health>();

			for (int i = 0; i < siblings.Length; i++) {
				if (siblings [i].currentHealth <= siblings [i].maxHealth) {
					siblings [i].currentHealth += healthPerFrame * 0.5f;
				}
			}
		}
	}
}
