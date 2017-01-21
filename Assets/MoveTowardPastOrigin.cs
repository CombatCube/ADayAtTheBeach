using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardPastOrigin : MonoBehaviour {
    private float translateDist = 0.1f;
    private Vector3 directionToOrigin;
	// Use this for initialization
	void Start () {
        directionToOrigin = Vector2.zero - (Vector2)transform.position;
        transform.up = directionToOrigin;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position += directionToOrigin.normalized * translateDist;
	}
}
