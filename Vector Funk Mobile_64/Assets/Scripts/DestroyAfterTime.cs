using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour {

    public float lifeTime, startTime;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if(Time.time-startTime>=lifeTime){
            Destroy(gameObject);
        }
	}
}
