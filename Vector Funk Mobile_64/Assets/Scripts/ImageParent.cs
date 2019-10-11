using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageParent : MonoBehaviour {

    public RectTransform rt;


    // Use this for initialization
    void Start () {
        rt = GetComponent<RectTransform>();
        rt.localPosition = new Vector3(1700 - (PlayerPrefs.GetInt("setBall") * 200), 0, 0);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
