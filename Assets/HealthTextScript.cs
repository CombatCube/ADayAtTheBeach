using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTextScript : MonoBehaviour {

	private Canvas mainCanvas;
	private GameObject healthTextObject;
	private GameObject healthBarBackground;
	private GameObject healthBarForeground;

	private static string FONT_FILE = "Arial.ttf";
	private static int FONT_SIZE = 18;

	private static string HEALTH_BAR_FOREGROUND = "greenhealth";
	private static string HEALTH_BAR_BACKGROUND = "redhealth";
	private static int HEALTH_BAR_WIDTH = 80;
	private static int HEALTH_BAR_HEIGHT = 30;
	private static int HEALTH_BAR_BORDER_PX = 2f;

	//How far above the sprite does the health bar float?
	private static float FLOATING_HEIGHT = 0.5f;

	// Use this for initialization
	void Start () {
		//Create a new UI objects in the canvas
		mainCanvas = GameObject.Find ("Canvas").GetComponent<Canvas> ();
		buildUIObject (ref healthBarBackground, mainCanvas);
		buildUIObject (ref healthBarForeground, mainCanvas);
		buildUIObject (ref healthTextObject, mainCanvas);

		//Build the text
		Text healthText = healthTextObject.AddComponent<Text> ();
		Font ArialFont = (Font)Resources.GetBuiltinResource (typeof(Font), FONT_FILE);
		healthText.font = ArialFont;
		healthText.material = ArialFont.material;
		healthText.alignment = TextAnchor.MiddleCenter;
		healthText.fontSize = FONT_SIZE;
		healthTextObject.GetComponent<RectTransform> ().sizeDelta = new Vector2 (HEALTH_BAR_WIDTH, HEALTH_BAR_HEIGHT);

		//Bar background
		Image bg = healthBarBackground.AddComponent<Image> ();
		Sprite bgSprite = Resources.Load<Sprite> (HEALTH_BAR_BACKGROUND);
		bg.sprite = bgSprite;
		healthBarBackground.GetComponent<RectTransform> ().sizeDelta = new Vector2 (HEALTH_BAR_WIDTH, HEALTH_BAR_HEIGHT);

		//Bar foreground
		Image fg = healthBarForeground.AddComponent<Image> ();
		Sprite fgSprite = Resources.Load<Sprite> (HEALTH_BAR_FOREGROUND);
		fg.sprite = fgSprite;
		fg.type = Image.Type.Filled;
		fg.fillMethod = Image.FillMethod.Horizontal;
		healthBarForeground.GetComponent<RectTransform> ().sizeDelta = new Vector2 (HEALTH_BAR_WIDTH, HEALTH_BAR_HEIGHT);

		//Update text
		updateHealth();

		//Set position
		healthText.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		SpriteRenderer spr = gameObject.GetComponent<SpriteRenderer> ();
		
		snapUIToSelf (ref healthTextObject, new Vector3(0,spr.bounds.size.y/2f + FLOATING_HEIGHT,0), new Vector3(0,0,0));
		snapUIToSelf (ref healthBarBackground, new Vector3(0,spr.bounds.size.y/2f + FLOATING_HEIGHT,0), new Vector3(0,0,0));
		snapUIToSelf (ref healthBarForeground, new Vector3(0,spr.bounds.size.y/2f + FLOATING_HEIGHT,0), new Vector3(HEALTH_BAR_BORDER_PX,0,0));

		updateHealth ();
	}

	private void buildUIObject(ref GameObject gameObject, Canvas canvas){
		gameObject = new GameObject();
		gameObject.transform.SetParent(canvas.transform);
	}

	private void addImage(ref GameObject gameObject, string filename) {
	}

	private void updateHealth() {
		Tower t = gameObject.GetComponent<Tower> ();
		Text healthText = healthTextObject.GetComponent<Text> ();

		healthText.text = t.currentHealth + "/" + t.totalHealth;

		Image barForeground = healthBarForeground.GetComponent<Image> ();
		barForeground.fillAmount = (float)t.currentHealth / t.totalHealth;
	}

	private void snapUIToSelf(ref GameObject ui, Vector3 worldOffset, Vector3 uiOffset){
		ui.transform.position = Camera.main.WorldToScreenPoint (gameObject.transform.position + worldOffset) + uiOffset;
	}
}
