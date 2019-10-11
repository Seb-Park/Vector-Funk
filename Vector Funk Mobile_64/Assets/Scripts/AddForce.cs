using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
	public float displacement = 0.3f;

	// Use this for initialization
	void Start () {
		displacement = Random.Range (0.2f,0.3f);
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//rb.AddForce (new Vector3 (0,0,-speed*10));
		transform.position=new Vector3(transform.position.x,transform.position.y,transform.position.z-displacement*Time.timeScale);
	}
}
