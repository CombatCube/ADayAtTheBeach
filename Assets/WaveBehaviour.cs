using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveBehaviour : MonoBehaviour {
    public defenseCreator defense;
    public ParticleSystem particles;
	public float destroyAfterSeconds = 25f;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, destroyAfterSeconds);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
