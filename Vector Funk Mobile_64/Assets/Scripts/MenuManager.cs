using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GooglePlayGames;

public class MenuManager : MonoBehaviour {

	public Rigidbody rb;
	public Canvas canvas;
    public Text crystalCount;
    public int totalCrystals;
	public GameObject[] options;
    public GameObject[] roads;
    public int sceneTrigger;
    public int limit=5;
    public GameObject connectedMenu;
    public GameObject disconnectedMenu;
    //public GameObject road1;
    //public GameObject road2;
    //public GameObject road3;
    //public GameObject road4;



    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f;
        sceneTrigger = (PlayerPrefs.GetInt("prefTheme"));
        if (PlayerPrefs.GetInt("prefTheme") != 0) {
            UpdateRoad(sceneTrigger);
        }else{
            UpdateRoad(0);
        }
        totalCrystals = (int)PlayerPrefs.GetFloat("Crystals");
        crystalCount.text = totalCrystals.ToString();
        //Initiate google play
        PlayGamesPlatform.Activate();
        OnConnectionResponse(PlayGamesPlatform.Instance.localUser.authenticated);
        //connectToPlay();
    }

    // Update is called once per frame
    void Update () {
        totalCrystals = (int)PlayerPrefs.GetFloat("Crystals");
        crystalCount.text = totalCrystals.ToString();
    }

    //public void changeScenePos(){
    //    sceneTrigger++;
    //    if (sceneTrigger>=roads.Length){
    //        sceneTrigger = 0;
    //    }
    //    UpdateRoad(sceneTrigger);
    //    Debug.Log("theme number"+sceneTrigger);
    //    PlayerPrefs.SetInt("prefTheme", sceneTrigger);
    //}

    //public void changeSceneNeg()
    //{
    //    sceneTrigger--;
    //    if (sceneTrigger < 0)
    //    {
    //        sceneTrigger = roads.Length - 1;
    //    }
    //    UpdateRoad(sceneTrigger);
    //    Debug.Log("theme number" + sceneTrigger);
    //    PlayerPrefs.SetInt("prefTheme", sceneTrigger);
    //}

    public void UpdateRoad(int index){

        //if(index==1){
        //    road1.gameObject.SetActive(true);
        //    road2.gameObject.SetActive(false);
        //    road3.gameObject.SetActive(false);
        //    road4.gameObject.SetActive(false);
        //}
        //else if (index == 2){
        //    road1.gameObject.SetActive(false);
        //    road2.gameObject.SetActive(true);
        //    road3.gameObject.SetActive(false);
        //    road4.gameObject.SetActive(false);
        //}
        //else if (index == 3)
        //{
        //    road1.gameObject.SetActive(false);
        //    road2.gameObject.SetActive(false);
        //    road3.gameObject.SetActive(true);
        //    road4.gameObject.SetActive(false);
        //}
        //else if (index == 4)
        //{
        //    road1.gameObject.SetActive(false);
        //    road2.gameObject.SetActive(false);
        //    road3.gameObject.SetActive(false);
        //    road4.gameObject.SetActive(true);
        //}

        //else if (index == 4)
        //{
        //    road1.gameObject.SetActive(false);
        //    road2.gameObject.SetActive(false);
        //    road3.gameObject.SetActive(false);
        //    road4.gameObject.SetActive(true);
        //}


        for (int i = 0; i < roads.Length; i++)
        {
            Debug.Log(roads.Length);
            if (i != index)
            {
                roads[i].gameObject.SetActive(false);
            }
            else {
                roads[i].gameObject.SetActive(true);
            }
        }

    }

	public void quitGame(){
		Application.Quit ();
	}

    public void connectToPlay(){
        Social.localUser.Authenticate((bool success) =>
        {
            OnConnectionResponse(success);
        });
    }

    private void OnConnectionResponse(bool authenticated){
        connectedMenu.SetActive(authenticated);
        disconnectedMenu.SetActive(!authenticated);
        if (authenticated) UnlockAchievement(VFGPS.achievement_login);
        Debug.Log("Connected to Google Play " + authenticated);
    }

    public void OnAchievementClick(){
        if(Social.localUser.authenticated)
        {
            Social.ShowAchievementsUI();
        }
    }

    public void UnlockAchievement(string achievementID){
        Social.ReportProgress(achievementID, 100.0, (bool success) =>
        {
            Debug.Log("Achievement Unlocked" + success.ToString());
        });
    }

    public void OnLeaderboardClick(){
        if(Social.localUser.authenticated){
            Social.ShowLeaderboardUI();
        }
    }
    public void ReportScore(int score){
        Social.ReportScore(score,VFGPS.leaderboard_high_score,(bool success)=> { Debug.Log("reported score"+success.ToString()); });
    }

    public void ReportHigh()
    {
        int score = (int)(PlayerPrefs.GetFloat("HighScore")*100);
        Social.ReportScore(score, VFGPS.leaderboard_high_score, (bool success) => { Debug.Log("reported score" + success.ToString()); });
    }

    public void Play(){
		rb.useGravity = true;
        Debug.Log(rb.useGravity);
		canvas.gameObject.SetActive (false);
	}

}
