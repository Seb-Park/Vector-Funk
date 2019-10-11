using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {

        Advertisement.Initialize("1612442");
    
	}
	
    public void playAd(){
        if(Advertisement.IsReady("video")){
            Advertisement.Show("video", new ShowOptions() { resultCallback = HandleAdResult });
            Debug.Log("ad shown?");

        }else{
            Debug.Log("Ad ain't ready");
        }
    }

    public void playRewardsAd(){
        if (Advertisement.IsReady("rewardedVideo"))
        {
            Advertisement.Show("rewardedVideo", new ShowOptions() { resultCallback = RewardAdResult });
            Debug.Log("ad shown?");

        }
        else
        {
            Debug.Log("Ad ain't ready");
        }
    }



    private void HandleAdResult(ShowResult result){
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("Finished the ad");
                break;
            case ShowResult.Skipped:
                Debug.Log("skipped the ad");
                break;
            case ShowResult.Failed:
                Debug.Log("failed advertisement");
                break;
        }
    }

    void RewardAdResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                PlayerPrefs.SetFloat("Crystals", PlayerPrefs.GetFloat("Crystals") + 5);
                break;
            case ShowResult.Skipped:
                Debug.Log("skipped the ad");
                break;
            case ShowResult.Failed:
                Debug.Log("failed advertisement");
                break;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
