using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClickExample : MonoBehaviour {
	public Button yourButton;

	void Start () {
	}

	public void OnClick(){
		print("You have clicked the button!");
	}
}