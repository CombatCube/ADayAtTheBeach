using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public GameObject wave;
	private float TimeRemaining;
	new 
	// Use this for initialization
	void Start () {
		SpawnWave ();
	}
	
	// Update is called once per frame
	void Update () {
		TimeRemaining = 2.0f;
		TimeRemaining -= Time.deltaTime;
		while (TimeRemaining > 0) {
			
		}
	
	}

	public void SpawnWave () {
		int timeuntilwave;
		int power;
		GameObject newwave = Instantiate (wave);
		newwave.transform.position = Random.insideUnitCircle;
		newwave.transform.position += newwave.transform.position.normalized * 2f;
		newwave.transform.LookAt(Vector3.zero);

	}
}
