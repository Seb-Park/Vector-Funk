using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour {

    public RectTransform rt;
    public float targetY = 1100;
    public float maxTarget;
    public float minTarget;
    public float speed = .1f;
    public MenuManager menu;
    public Button actButton;
    public bool isVisible;

    // Use this for initialization
    void Start () {
        targetY = maxTarget;
        rt = GetComponent<RectTransform>();
        rt.localPosition = new Vector3(0, targetY, 0);
        actButton.enabled = true;
    }

    // Update is called once per frame
    void Update () {
        Vector3 targetPosition = new Vector3(0, targetY, 0);
        rt.anchoredPosition = Vector3.Slerp(rt.localPosition, targetPosition, speed);
    }
    public void bringDown()
    {
        isVisible = true;
        targetY = minTarget;
        actButton.enabled = false;
    }

    public void bringUp()
    {
        isVisible = false;
        targetY = maxTarget;
        actButton.enabled = true;
    }

}
