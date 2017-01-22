using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour {
	public HEALTH_TYPE healthType = HEALTH_TYPE.Health;

	private Text healthText;
	private Image foreground;

	public enum HEALTH_TYPE {
		Health,
		Water
	};

	void Start() {
		healthText = gameObject.transform.Find("Text").gameObject.GetComponent<Text> ();
		foreground = gameObject.transform.Find("Foreground").gameObject.GetComponent<Image> ();
	}

	public void updateHealth(float currentHealth, float maxHealth){
		switch (healthType) {
		case HEALTH_TYPE.Health:
			healthText.text = (int)currentHealth + "/" + (int)maxHealth;
			foreground.fillAmount = currentHealth / maxHealth;
			break;
		case HEALTH_TYPE.Water:
			healthText.text = (int)(maxHealth - currentHealth) + "/" + (int)maxHealth;
			foreground.fillAmount = (maxHealth - currentHealth) / maxHealth;
			break;
		}
	}
}
