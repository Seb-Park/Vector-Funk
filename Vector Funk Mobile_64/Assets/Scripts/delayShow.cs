using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delayShow : MonoBehaviour {

    public long minutesDelay;
    public long lastTimeTurnedOn;
    public long currentTime;
    public GameObject timedObject;
    public GameObject alternate;
    public string timedObjectName;
    [SerializeField]
    private long millisPassed;

    // Use this for initialization
    void Start()
    {
        //Debug.Log("the string is" + PlayerPrefs.GetString("lastTimeTurnedOn" + timedObjectName));
        if(PlayerPrefs.GetString("lastTimeTurnedOn" + timedObjectName).Equals("")){
            lastTimeTurnedOn = 0;
        }
        else
        {
            lastTimeTurnedOn = long.Parse(PlayerPrefs.GetString("lastTimeTurnedOn" + timedObjectName));
        }

        currentTime = CurrentTimeMillis();
        millisPassed = currentTime - lastTimeTurnedOn;

        //if the minute delay has passed since the last time the button was turned on, we can show the object
        //if (millisPassed>=minutesDelay*60000)
        //{
        //    timedObject.SetActive(true);
        //    alternate.SetActive(false);
        //    //otherwise, don't show the play ad button.
        //}else{
        //    timedObject.SetActive(false);
        //    alternate.SetActive(true);
        //}

//Set these objects inactive or active depending on whether enough time has passed.
        timedObject.SetActive(millisPassed>=minutesDelay*60000);
        alternate.SetActive(!(millisPassed >= minutesDelay * 60000));
    }

    public void hide(){
        lastTimeTurnedOn = CurrentTimeMillis();
        timedObject.SetActive(false);
        PlayerPrefs.SetString("lastTimeTurnedOn"+ timedObjectName, lastTimeTurnedOn.ToString());
        alternate.SetActive(!(millisPassed >= minutesDelay * 60000));

    }

    static readonly System.DateTime Jan1st1970 = new System.DateTime
    (1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);

    public static long CurrentTimeMillis()
    {
        return (long)(System.DateTime.UtcNow - Jan1st1970).TotalMilliseconds;
    }

    // Update is called once per frame
    void Update () {
        currentTime = CurrentTimeMillis();
        millisPassed = currentTime - lastTimeTurnedOn;
        alternate.SetActive(!(millisPassed >= minutesDelay * 60000));

    }
}
