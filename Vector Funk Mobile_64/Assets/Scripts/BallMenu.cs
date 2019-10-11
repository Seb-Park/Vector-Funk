using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMenu : MonoBehaviour {

    public int ballIndex;
    public int limit = 7;
    public GameObject[] images;
    public GameObject green;
    public Text selectText;
    public MoneyManager moneyManager;
    public GameObject crystalIcon;
    public GameObject red;
    public RectTransform ImageParent;
    public bool isStarted;
    public PopUp popup;
    public AudioManager am;

    // Use this for initialization
    void Start()
    {
        am = FindObjectOfType<AudioManager>();
        //PlayerPrefs.SetFloat("Crystals", 1100);
//        ballIndex = PlayerPrefs.GetInt("setBall");
        resetScrollPosition();
        //        ballIndex = PlayerPrefs.GetInt("setBall");
        //for (int i = 0; i < images.Length; i++){
        //    images[i].GetComponent<BallImageSize>().updateOrigin();
        //}
        //setScrollPosition();
        popup = gameObject.GetComponent<PopUp>();


    }

    public void showImage(){
        for (int i = 0; i < images.Length; i++)
        {
            if (ballIndex == i)
            {
                images[i].gameObject.SetActive(true);
            }
            else
            {
                images[i].gameObject.SetActive(false);
            }
        }
    }

    public void increaseBall(){
        ballIndex++;
        if (ballIndex >= images.Length)
        {
            ballIndex = 0;
        }

        Debug.Log("Ball number "+ballIndex);
    }

    public void decreaseBall()
    {
        ballIndex--;
        if (ballIndex < 0)
        {
            ballIndex = images.Length-1;
        }

        Debug.Log("Ball number " + ballIndex);
    }

    public void checkWhichBall(){
        for (int i = 0; i < images.Length; i++)
            {
            if (images[i].GetComponent<RectTransform>().localScale.x>=0.5f)
                {
                if (ballIndex != i) { am.play("Click"); }
                ballIndex = i;
                }

            }
    }

    public void selectTheme()
    {
        if (moneyManager.paid[ballIndex] <= 0||moneyManager.paid[ballIndex]<moneyManager.prices[ballIndex])//if the price is paid off
        {
            PlayerPrefs.SetInt("setBall", ballIndex);
        }
        else{
            if((int)PlayerPrefs.GetFloat("Crystals")>=moneyManager.prices[ballIndex]){//if i have more crystals than the price
                //PlayerPrefs.SetInt(moneyManager.type + ballIndex + "price", /*PlayerPrefs.GetInt(moneyManager.type + ballIndex + "price")*/-1*(moneyManager.prices[ballIndex]));//subtract the price from the paid off player pref
                PlayerPrefs.SetInt(moneyManager.names[ballIndex] + "Price", /*PlayerPrefs.GetInt(moneyManager.type + ballIndex + "price")*/-1 * (moneyManager.prices[ballIndex]));//subtract the price from the paid off player pref
               
                PlayerPrefs.SetFloat("Crystals", PlayerPrefs.GetFloat("Crystals") - moneyManager.prices[ballIndex]);//subtracts the price of hte ball from my crystal count
                moneyManager.updatePrices();
            }
        }
    }

    public void checkSelected()
    {
        if (ballIndex == PlayerPrefs.GetInt("setBall"))
        {
            selectText.text = "SELECTED";
            green.gameObject.SetActive(true);
            crystalIcon.gameObject.SetActive(false);
            red.gameObject.SetActive(false);
        }
        else if (moneyManager.paid[ballIndex] > 0){
            selectText.text = (moneyManager.paid[ballIndex]).ToString();//if I haven't bought the ball change "select" to the price of the ball
            green.gameObject.SetActive(false);
            crystalIcon.gameObject.SetActive(true);
            if(moneyManager.prices[ballIndex] > PlayerPrefs.GetFloat("Crystals")){
                red.gameObject.SetActive(true);//make the box red if the ball is unpurchaseable
            }else{
                red.gameObject.SetActive(false);
            }
        }
        else
        {
            selectText.text = "SELECT";
            green.gameObject.SetActive(false);
            crystalIcon.gameObject.SetActive(false);
            red.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update () {
        //showImage();
        checkSelected();
        checkWhichBall();
        fixScrollPosition();
        resetScrollOnInvisible();
    }

    public void resetScrollOnInvisible(){
        if(!popup.isVisible){
            setScrollPosition();
        }
    }

    private void LateUpdate()
    {
        if (!isStarted)
        {
            startScroller();
        }
    }
    public void startScroller(){
        setScrollPosition();
        isStarted = true;
    }


    public void setScrollPosition(){
        ballIndex = (PlayerPrefs.GetInt("setBall"));

            ImageParent.localPosition = new Vector3(1700 - (PlayerPrefs.GetInt("setBall") * 200), 0, 0);

        ballIndex = (PlayerPrefs.GetInt("setBall"));
        //setScrollPosition(ballIndex);
        //setScrollPosition(PlayerPrefs.GetInt("setBall"));
        //if(ImageParent.localPosition != new Vector3(1700 - (PlayerPrefs.GetInt("setBall") * 200), 0, 0)){
        //    setScrollPosition(PlayerPrefs.GetInt("setBall"));
        //}
    }

    public void checkWrongScrollPos(){
        if(ImageParent.localPosition != new Vector3(1700 - (PlayerPrefs.GetInt("setBall") * 200), 0, 0)){
            setScrollPosition(PlayerPrefs.GetInt("setBall"));

        }
    }

    public void nextBall(){
        ImageParent.localPosition = new Vector3(1700 - (ballIndex * 200), 0, 0);
        if(!(ballIndex>=images.Length-1)){
            ballIndex++;

            ImageParent.localPosition = new Vector3(1700 - (ballIndex * 200), 0, 0);
        }
    }

    public void prevBall()
    {
        if (!(ballIndex <=0))
        {
            ImageParent.localPosition = new Vector3(1700 - (ballIndex-1 * 300), 0, 0);

            ballIndex--;

            ImageParent.localPosition = new Vector3(1700 - (ballIndex * 300), 0, 0);
        }
    }

    public void setScrollPosition(int bIndex)
    {
        ImageParent.localPosition = new Vector3((1700 - (bIndex * 200)), 0, 0);
    }

    public void resetScrollPosition()
    {
        ImageParent.localPosition = new Vector3(1700 - (0 * 200), 0, 0);
    }

    public void fixScrollPosition(){
        //ballIndex = (PlayerPrefs.GetInt("setBall"));

        float targetX = 1700 - (ballIndex * 200);
        Vector3 scrollTarget = new Vector3(targetX, 0, 0);
        ImageParent.localPosition = Vector3.Slerp(ImageParent.localPosition, scrollTarget, .2f);
    }

}
