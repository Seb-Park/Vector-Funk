using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -2||transform.position.z<-30) {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag ("Boundaries")) {
			Destroy (this.gameObject);
		}
	}
}
