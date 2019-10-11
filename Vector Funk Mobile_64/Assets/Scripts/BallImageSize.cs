using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallImageSize : MonoBehaviour {

    public RectTransform rt;
    public float scale;
    public GameObject firstBall;
    [SerializeField]
    private float centerPos;
    [SerializeField]
    private float xpos;

	// Use this for initialization
	void Start () {
        //defaultSize = 100;
        firstBall = GameObject.Find("/Canvas/BallSelector/ScrollRect/ImageParent/Image");
        centerPos = (Mathf.Abs(firstBall.GetComponent<RectTransform>().position.x));


        rt = GetComponent<RectTransform>();

        //firstBall = GameObject.Find("/Canvas/BallSelector").GetComponent<BallMenu>().images[PlayerPrefs.GetInt("setBall")];

        scale = 50 / ((Mathf.Abs(rt.position.x - centerPos)));
        //centerPos = (Mathf.Abs(whiteBall.GetComponent<RectTransform>().position.x - centerPos)) / 5;
    }
    public void updateOrigin(){
        firstBall = GameObject.Find("/Canvas/BallSelector/ScrollRect/ImageParent/Image");

        centerPos = (Mathf.Abs(firstBall.GetComponent<RectTransform>().position.x));
        scale = 50 / ((Mathf.Abs(rt.position.x - centerPos)));


    }
    public void newOrigin(int index){
        firstBall = GameObject.Find("/Canvas/BallSelector").GetComponent<BallMenu>().images[index];
        //firstBall = firstBall.GetComponent<BallMenu>().images[firstBall.GetComponent<BallMenu>().ballIndex];
        centerPos = (Mathf.Abs(firstBall.GetComponent<RectTransform>().position.x));

    }

    // Update is called once per frame
    void Update () {
        rt.transform.localScale = new Vector3(scale, scale, scale);
        //scale = 50 / ((Mathf.Abs(rt.position.x - centerPos)));
        //if ((Mathf.Abs(rt.position.x - centerPos)) / 50 > 1)
        if(50/(Mathf.Abs(rt.position.x - centerPos)) <= 1)
        {
            scale = 50 / ((Mathf.Abs(rt.position.x - centerPos)) );
        }
        else{
            scale = 1;
        }
        xpos = rt.position.x;


    }
}
