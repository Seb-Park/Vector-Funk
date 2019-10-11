using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    public GameObject[] roads;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision other){
        //if (other.gameObject.CompareTag ("PlayGame1"))
        //{
        //	SceneManager.LoadScene (1);
        //}
        //else if (other.gameObject.CompareTag("PlayGame2"))
        //{
        //    SceneManager.LoadScene(2);
        //}
        //else if (other.gameObject.CompareTag("PlayGame3"))
        //{
        //    SceneManager.LoadScene(3);
        //}
        //else if (other.gameObject.CompareTag("PlayGame4"))
        //{
        //    SceneManager.LoadScene(4);
        //}
        //else if (other.gameObject.CompareTag("PlayGame5"))
        //{
        //    SceneManager.LoadScene(5);
        //}
        for (int i = 0; i < roads.Length;i++){
            Debug.Log("checking if road number " + i +" is the correct road.");
            if(GameObject.ReferenceEquals(roads[i].gameObject, other.gameObject)){
                SceneManager.LoadScene(i+1);
                Debug.Log("Road number " + i +" is the correct road.");
            }
        }
    }



	}

