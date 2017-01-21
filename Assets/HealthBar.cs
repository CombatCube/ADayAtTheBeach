using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	public Health health;
	public GameObject healthBarUIPrefab;

	private Canvas mainCanvas;
	private GameObject healthBar;

	//How far above the sprite does the health bar float?
	private static float FLOATING_HEIGHT = 0.5f;

	// Use this for initialization
	void Start () {
		//Create a new UI objects in the canvas
		mainCanvas = GameObject.Find ("Canvas").GetComponent<Canvas> ();
		healthBar = Instantiate (healthBarUIPrefab);
		healthBar.transform.SetParent(mainCanvas.transform);
	}
	
	// Update is called once per frame
	void Update () {
		SpriteRenderer spr = gameObject.GetComponent<SpriteRenderer> ();
		snapUIToSelf (ref healthBar, new Vector3 (0, spr.bounds.size.y / 2f + FLOATING_HEIGHT, 0), new Vector3 (0, 0, 0));

		updateHealth ();
	}

	void OnDestroy() {
		// delete every single health bar canvas
	}

	private void updateHealth() {
		Text healthText = healthBar.transform.Find ("Text").gameObject.GetComponent<Text> ();

		healthText.text = (int)health.currentHealth + "/" + (int)health.maxHealth;

		Image barForeground = healthBar.transform.Find("Foreground").gameObject.GetComponent<Image> ();
		barForeground.fillAmount = health.currentHealth / health.maxHealth;
	}

	private void snapUIToSelf(ref GameObject ui, Vector3 worldOffset, Vector3 uiOffset){
		ui.transform.position = Camera.main.WorldToScreenPoint (gameObject.transform.position + worldOffset) + uiOffset;
	}
}
