using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGraphic : MonoBehaviour {

	public Transform player;
	public float rotSpeed = 30f;
	public Vector3 offset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate (new Vector3(rotSpeed,0,0));
		transform.position = player.position + offset;
	}
}
