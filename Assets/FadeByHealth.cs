using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeByHealth : MonoBehaviour {

	public Health health;
	public SpriteRenderer spriteRenderer;
	
	// Update is called once per frame
	void Update () {
		float healthPercent = health.currentHealth / health.maxHealth;

		Color color = spriteRenderer.color;
		color.a = healthPercent;
		spriteRenderer.color = color;
	}
}
