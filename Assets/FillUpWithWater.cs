using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillUpWithWater : MonoBehaviour {

	private Health health;
	private SpriteRenderer spriteRenderer;

	private float trueAlpha;
	private float randomSpeed;

    private float waterScale;

	void Start() {
		health = gameObject.transform.parent.gameObject.GetComponent<Health> ();
		spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
		//randomSpeed = Random.Range (0.1f, 2.0f);
	}

	void Update () {
		//trueAlpha = 0.9f * (health.maxHealth - health.currentHealth) / health.maxHealth;

        SpriteRenderer childSP = GetComponentInChildren<SpriteRenderer>();
        waterScale = (health.maxHealth - health.currentHealth) / health.maxHealth;

        childSP.transform.localScale = new Vector3(waterScale, waterScale);

        //Color color = spriteRenderer.color;
		//color.a = trueAlpha + (0.2f * Mathf.Sin (randomSpeed*Time.time));
		//spriteRenderer.color = color;
	}
}
