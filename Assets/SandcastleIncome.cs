using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SandcastleIncome : MonoBehaviour {

	public MoneyManager moneyManager; 
	public Health sandcastleHealth; // put self into here
	public float incomeIntervalSeconds;

	private EventTrigger.Entry clickForIncome;
	private EventTrigger.Entry mouseEnter;
	private EventTrigger.Entry mouseExit;

	private bool incomeReady = false;

	private List<EventTrigger.Entry> allEntries = new List<EventTrigger.Entry>();
	public Texture2D sandcastleHover;

	// Use this for initialization
	void Start () {

		// create the on click trigger for collecting sand
		gameObject.AddComponent<EventTrigger> ();
		clickForIncome = new EventTrigger.Entry ();
		clickForIncome.eventID = EventTriggerType.PointerDown;
		clickForIncome.callback.AddListener ((eventData) => {
			collectIncome();
		});
		allEntries.Add (clickForIncome);

		// these two triggers are to enable mouseover only when sand is ready for collection
		mouseEnter = new EventTrigger.Entry ();
		mouseEnter.eventID = EventTriggerType.PointerEnter;
		mouseEnter.callback.AddListener ((eventData) => {
			Cursor.SetCursor (sandcastleHover, Vector2.zero, CursorMode.Auto);
		});
		allEntries.Add (mouseEnter);

		mouseExit = new EventTrigger.Entry ();
		mouseExit.eventID = EventTriggerType.PointerExit;
		mouseExit.callback.AddListener ((eventData) => {
			Cursor.SetCursor (null, Vector2.zero, CursorMode.Auto);
		});
		allEntries.Add (mouseExit);

		incomeIsReady ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDestroy() {
		Cursor.SetCursor (null, Vector2.zero, CursorMode.Auto);
	}

	IEnumerator waitForIncome() {
		yield return new WaitForSeconds (incomeIntervalSeconds);
		incomeIsReady ();
		
	}

	void incomeIsReady() {
		EventTrigger trigger = GetComponent<EventTrigger> ();
		trigger.triggers.AddRange (allEntries);
		incomeReady = true;
		StartCoroutine (rainbowKeepWhileIncomeReady());
	}


	void collectIncome() {
		moneyManager.GainMoney ((int)sandcastleHealth.currentHealth);
		EventTrigger trigger = GetComponent<EventTrigger> ();
		trigger.triggers.Clear ();
		Cursor.SetCursor (null, Vector2.zero, CursorMode.Auto);
		incomeReady = false;
		StartCoroutine (waitForIncome());
	}


	IEnumerator rainbowKeepWhileIncomeReady() {
		float hue = 0;
		while (incomeReady) {
			yield return new WaitForSeconds (0.05f);
			hue += 0.05f;
			gameObject.GetComponent<SpriteRenderer> ().color = Color.HSVToRGB(hue, 0.5f, 1);
			if (hue > 1) {
				hue = 0;
			}
		}
		gameObject.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1);
	}
}

