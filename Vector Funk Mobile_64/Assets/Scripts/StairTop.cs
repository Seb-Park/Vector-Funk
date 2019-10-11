using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairTop : MonoBehaviour {

	float startX;

	// Use this for initialization
	void Start () {
		startX = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(startX,transform.position.y, transform.position.z);
	}
}
