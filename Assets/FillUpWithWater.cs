using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillUpWithWater : MonoBehaviour {

	private Health health;
	private SpriteRenderer spriteRenderer;

	void Start() {
		health = gameObject.transform.parent.gameObject.GetComponent<Health> ();
		spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
	}

	void Update () {
		Color color = spriteRenderer.color;
		color.a = 0.9f * (health.maxHealth - health.currentHealth) / health.maxHealth;
		spriteRenderer.color = color;

		Debug.Log ("Setting alpha to: " + color.a);
	}
}
