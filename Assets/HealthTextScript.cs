using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTextScript : MonoBehaviour {

	private Canvas mainCanvas;
	private GameObject healthTextObject;
	private GameObject owningObject;

	// Use this for initialization
	void Start () {
		owningObject = gameObject;
		//Create a new UI object in the canvas
		mainCanvas = GameObject.Find ("Canvas").GetComponent<Canvas> ();
		healthTextObject = new GameObject ();
		healthTextObject.name = "TowerHealthText";
		healthTextObject.transform.SetParent (mainCanvas.transform);

		//Add text component
		Text healthText = healthTextObject.AddComponent<Text> ();
		Font ArialFont = (Font)Resources.GetBuiltinResource (typeof(Font), "Arial.ttf");
		healthText.font = ArialFont;
		healthText.material = ArialFont.material;
		healthText.alignment = TextAnchor.UpperCenter;
		healthText.fontSize = 18;


		//Update text
		updateHealth();

		//Set position
		healthText.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		healthTextObject.GetComponent<Text>().transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		updateHealth ();
	}

	void OnDestroy() {
		Destroy (healthTextObject);
	}

	private void updateHealth() {
		Tower t = gameObject.GetComponent<Tower> ();
		Text healthText = healthTextObject.GetComponent<Text> ();

		healthText.text = t.currentHealth + "/" + t.totalHealth;
	}
}
