using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepRotation : MonoBehaviour {

    public Vector3 rotation;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.eulerAngles = (rotation);
	}
}
