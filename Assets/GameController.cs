using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public GameObject wave;
	// Use this for initialization
	void Start () {
		SpawnWave ();
	}
	
	// Update is called once per frame
	void Update () {
		
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
