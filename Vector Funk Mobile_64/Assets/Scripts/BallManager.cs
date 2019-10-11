using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallManager : MonoBehaviour {

    public GameObject[] balls;

	// Use this for initialization
	void Start () {
        GameObject ball = Instantiate(balls[PlayerPrefs.GetInt("setBall")], (new Vector3(0,1,-21)), Quaternion.identity);
        ball.transform.parent = gameObject.transform;
        //Debug.Log("ball number " +PlayerPrefs.GetInt("setBall")+" is "+ball.transform.position);
        //Instantiate(balls[0], transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
