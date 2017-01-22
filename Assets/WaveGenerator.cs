using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGenerator : MonoBehaviour {

	public float timeBetweenWaves = 15;
	public GameObject wave;
	public float worldHeight = 10;
	public float worldWidth = 20;
	public float deltaTimeBetweenWaves = -1f;
    public AudioClip waveClip;
	public AudioClip backWaveClip;

    private float timeSinceLastWave = 5;

    void Start()
    {
    }
    
	// Update is called once per frame
	void Update () {
		timeSinceLastWave += Time.deltaTime;
		if (timeSinceLastWave >= timeBetweenWaves) {
			Debug.Log ("Spawning Wave");

			timeSinceLastWave = 0;

			if (timeBetweenWaves > 5) {
				timeBetweenWaves += deltaTimeBetweenWaves;
			}
			GameObject newWave = Instantiate (wave);

			AudioSource[] sources = newWave.GetComponents<AudioSource> ();

			sources [0].PlayOneShot (waveClip);
			sources[1].Play(44100 * 5);

            //Super hacky don't do this at home kids
            float xPosition = Random.Range (-1 * worldWidth, worldWidth);

			if (xPosition > 0) {
				newWave.transform.position = new Vector3 (xPosition - worldWidth/2, worldHeight/2f, -5f) * 1.5f;
			} else {
				newWave.transform.position = new Vector3 (xPosition + worldWidth/2, -1f * worldHeight/2f, -5f) * 1.5f;
			}
		}
	}
}
