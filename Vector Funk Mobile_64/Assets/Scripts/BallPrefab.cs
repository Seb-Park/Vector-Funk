using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPrefab : MonoBehaviour {

    public Vector3 rotOffset;

	// Use this for initialization
	void Start () {
        transform.Rotate(rotOffset);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
