using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

	public float health;
	public GameObject explosion;
	public Vector3 offset;
	public Transform player;

	// Use this for initialization
	void Start () {
		transform.position = player.transform.position + offset;
		health = 3f;
	//	explosion.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			this.gameObject.SetActive (false);
			//explosion.gameObject.SetActive(true);
		}
	}

	void OnCollisionEnter(Collision block){
		if(block.gameObject.CompareTag("Block")){
			health--;
		}
	}
	void LateUpdate(){
		transform.position = player.transform.position + offset;
	}
}
