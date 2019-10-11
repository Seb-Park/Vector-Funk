using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThemeMenu : MonoBehaviour {

    public RectTransform rt;
    public float targetY= 1100;
    public float speed = .1f;
    public Button themeButton;
    public MenuManager menu;
    public GameObject[] sampleImages;
    public int imageIndex;
    public int limit = 5;
    public Text selectText;
    public Image green;
    public Image red;
    public Button queryButton;
    public int[] prices;
    //public Button backButton;


    // Use this for initialization
    void Start () {
        rt   = GetComponent<RectTransform>();
        Debug.Log(rt.localPosition);
        rt.localPosition = new Vector3(0,1100,0);
        themeButton.enabled = true;
        imageIndex = PlayerPrefs.GetInt("prefTheme");
        Debug.Log("loading theme number"+imageIndex);
        queryButton.enabled = true;
    }



    // Update is called once per frame
    void Update () {
        Vector3 targetPosition = new Vector3(0, targetY, 0);
        rt.anchoredPosition = Vector3.Slerp(rt.localPosition,targetPosition,speed);
        showImage();
        checkSelected();
    }

    public void showImage(){
        for (int i = 0; i < sampleImages.Length;i++){
            if (imageIndex == i){
                sampleImages[i].gameObject.SetActive(true);
            }
            else{
                sampleImages[i].gameObject.SetActive(false);
            }
        }
    }

    public void checkSelected(){
        if(imageIndex == PlayerPrefs.GetInt("prefTheme")){
            selectText.text = "SELECTED";
            green.gameObject.SetActive(true);
            red.gameObject.SetActive(false);
        }
        else if(prices[imageIndex] > PlayerPrefs.GetFloat("HighScore")){
            selectText.text = "HS: "+prices[imageIndex].ToString();
            green.gameObject.SetActive(false);
            red.gameObject.SetActive(true);
        }
        else
        {
            selectText.text = "SELECT";
            green.gameObject.SetActive(false);
            red.gameObject.SetActive(false);
        }
    }

    public void bringDown (){
        imageIndex = PlayerPrefs.GetInt("prefTheme");
        targetY = 4;
        themeButton.enabled = false;
        queryButton.enabled = false;
    }

    public void bringUp(){
        targetY = 1100;
        themeButton.enabled = true;
        queryButton.enabled = true;
    } 

    public void changeScenePos()
    {
        imageIndex++;
        if (imageIndex >= sampleImages.Length)
        {
            imageIndex = 0;
        }
    }

    public void changeSceneNeg()
    {
        imageIndex--;
        if (imageIndex < 0)
        {
            imageIndex = sampleImages.Length - 1;
        }

    }

    public void selectTheme(){
        if (PlayerPrefs.GetFloat("HighScore") >= prices[imageIndex])
        {
            menu.UpdateRoad(imageIndex);
            PlayerPrefs.SetInt("prefTheme", imageIndex);
            Debug.Log("we chose theme number" + imageIndex);
        }
    }

}
