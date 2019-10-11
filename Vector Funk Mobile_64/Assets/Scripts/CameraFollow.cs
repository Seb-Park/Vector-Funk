using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GameObject player;
	private float offset;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
		offset = transform.position.y - player.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(transform.position.x,player.transform.position.y+offset,transform.position.z);
	}


}

