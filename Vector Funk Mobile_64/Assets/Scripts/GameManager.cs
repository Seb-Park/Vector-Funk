using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using GooglePlayGames;

public class GameManager : MonoBehaviour {

	public bool paused = false;
	public float slowness = 10f;
	public Text PauseSign;
	public Text PauseText;
	public Button PauseButton;
	public Button PlayButton;
	public Rigidbody rb;
	public Text GameOver;
	public Text Restart;
	public GameObject blockPrefab;
	public GameObject shortBlock;
	public Text MainMenu;
	public bool isDead = false;
	public GameObject blockSpawner;
	public float startTime;
	public float score = 0;
	public Text meters;
	public float speedTime = 10f;
	public float speedScale = 1.1f;
	public Text finalScore;
	public Text pausedRestart;
	public Text highScore;
	public float high;
	public Text highDisplay;
	//public GameObject PowerUpSound;
	public float timeSpeed;
	//public SphereCollider ball;
    public int scene;
    public int crystals;
    public bool crystalsAdded = false;
    public GameObject crystalIcon;
    public Text crystalCount;
    public GameObject newImage;
    public bool isNewHigh;
    public bool isRestartable, isAdPlayed;
    public Button restartButton;

	public void Start(){
        isAdPlayed = false;
		Time.timeScale = 1;
        scene = SceneManager.GetActiveScene().buildIndex;
        isDead = false;
		//Debug.Log (Time.fixedDeltaTime);
		PauseText.gameObject.SetActive (true);
		PauseText.text = "";
        PauseButton.gameObject.SetActive (true);
        //Destroy(PauseButton.gameObject);
        PlayButton.gameObject.SetActive (false);
		pausedRestart.text = "";
        restartButton = pausedRestart.gameObject.GetComponent<Button>();
        restartButton.enabled = false;
        GameOver.gameObject.SetActive (true);
		GameOver.text = "";
		Restart.gameObject.SetActive (true);
		Restart.text = "";
		finalScore.gameObject.SetActive (true);
		finalScore.text = "";
		blockPrefab.gameObject.SetActive (true);
		MainMenu.gameObject.SetActive (true);
		MainMenu.text = "";
		shortBlock.gameObject.SetActive (true);
		blockSpawner.gameObject.SetActive (true);
        crystalIcon.gameObject.SetActive(false);
        crystalCount.text = "";
		score = 0;
        crystals = 0;
        meters.text = "0m";
		startTime = Time.time;
        //Debug.Log(Time.time);
		highScore.gameObject.SetActive (true);
		highScore.text = "";
		highDisplay.gameObject.SetActive (true);
		highDisplay.text = "";
		timeSpeed = 1;
        newImage.gameObject.SetActive(false);
        isRestartable = false;
        PlayGamesPlatform.Activate();
        if(scene == 7 && PlayerPrefs.GetInt("setBall") == 7){
            UnlockAchievement(VFGPS.achievement_inverted_funk);
        }
    }

    public void restartMethod(){
        if (isRestartable||(isDead&&!Advertisement.isShowing))
        {
            Debug.Log("restarting");
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f;
            SceneManager.LoadScene(scene);
        }
	}

	public void MenuMethod(){
        if (isRestartable || isDead)
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f;
            SceneManager.LoadSceneAsync(0);
        }
	}

	public void EndGame(){
//		Debug.Log ("You Lose");
		StartCoroutine (GameEnd());
		//PauseButton.gameObject.SetActive(true);
	}


    IEnumerator GameEnd()
    {

        //	PauseButton = GetComponent<Button> ();
        if (score > PlayerPrefs.GetFloat("HighScore"))
        {
            isNewHigh = true;
            PlayerPrefs.SetFloat("HighScore", score);
        }
        if (!crystalsAdded) { 
            crystals = (int)(score / 10);
            PlayerPrefs.SetFloat("Crystals", PlayerPrefs.GetFloat("Crystals") + crystals);
//            Debug.Log(crystals + " crystals earned");
            crystalsAdded = true;
//            Debug.Log(PlayerPrefs.GetFloat("Crystals"));
        }
                if (score > PlayerPrefs.GetFloat("HighScore")){
            newImage.gameObject.SetActive(true);
        }
        rb = GetComponent<Rigidbody>();
		Time.timeScale =1f/slowness;
        //Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;
        Time.fixedDeltaTime = 0.02f / slowness;
        PauseButton.gameObject.SetActive (false);
		PauseButton.enabled = false;
		isDead = true;
		finalScore.text = score.ToString("f2")+"m";
		meters.text = "";
		//PowerUpSound.SetActive (false);
        int randomAd = Random.Range(0, 5);
        if(randomAd<1&&!isAdPlayed){
            playAd();
            isAdPlayed = true;
        }
        isAdPlayed = true;
        //if(PowerUpSound.gameObject!=null)Destroy(PowerUpSound);
        //		rb.AddExplosionForce(200, rb.transform.position, 20, 3.0F);
        yield return new WaitForSeconds (0.2f);
		GameOver.color = new Vector4 (GameOver.color.r,GameOver.color.g,GameOver.color.b,255);
		GameOver.text = "GAME OVER";
		highDisplay.text = "HIGH:";
		highScore.text = PlayerPrefs.GetFloat ("HighScore").ToString("f2")+"m";
        if(isNewHigh){
            newImage.gameObject.SetActive(true);
            ReportHigh();
        }
        Time.timeScale = 1f;
        //		Time.fixedDeltaTime = Time.fixedDeltaTime * slowness;
        Time.fixedDeltaTime = 0.02f;
        //		blockPrefab.gameObject.SetActive (false);
//		shortBlock.gameObject.SetActive (false);
		blockSpawner.gameObject.SetActive(false);
		Restart.text = "RESTART";
		MainMenu.text = "MAIN MENU";
        crystalIcon.gameObject.SetActive(true);
        crystalCount.text = "+" + crystals.ToString();
	}



	public void Pause(){

		paused = !paused;

			if (paused){
//                Debug.Log("pause");
				timeSpeed = Time.timeScale;
				PauseSign.text = ">";
				Time.timeScale =0;
                pausedRestart.gameObject.SetActive(true);
                PauseText.text = "PAUSED";
                restartButton.enabled = true;
                MainMenu.text = "MAIN MENU";
				pausedRestart.text = "RESTART";
                isRestartable = true;
                PlayButton.gameObject.SetActive (true);
			}

			if (!paused){
//                Debug.Log("unpause");
                PauseSign.text = "II";
                pausedRestart.gameObject.SetActive(false);
                pausedRestart.text = "";
                restartButton.enabled = false;
                isRestartable = false;
				PauseText.text = "";
				MainMenu.text = "";
				PlayButton.gameObject.SetActive (false);
				Time.timeScale =timeSpeed;
			}
		
		}

    
    public void playAd()
    {
        Debug.Log("trying to show an ad...");
        if (Advertisement.IsReady("video"))
        {
            isRestartable = false;
            Advertisement.Show("video", new ShowOptions() { resultCallback = HandleAdResult });
            Debug.Log("ad shown?");

        }
        else
        {
            Debug.Log("Ad ain't ready");
            isRestartable = true;

        }
    }

    private void HandleAdResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("reward");
                isRestartable = true;
                break;
            case ShowResult.Skipped:
                Debug.Log("skipped the ad");
                isRestartable = true;

                break;
            case ShowResult.Failed:
                Debug.Log("failed advertisement");
                isRestartable = true;
                break;
        }
    }


    public void Update(){

		if (!paused && !isDead) {
            score = (Time.time - startTime)/1.5f;
			////StartCoroutine (scoreCount());
			meters.text = score.ToString ("f1")+"m";
		}
			

		if (Input.GetKeyDown("p")){
			
			Pause ();

		}

		if (Input.GetKeyDown ("space")||Input.GetKeyDown("return")) {
			if (isDead) {	
				restartMethod ();
			} else {
                Pause ();
                //Debug.Log("Pause Method");
			}
		}

		if(score>=speedTime){
			if(score<35){
			Time.timeScale = Time.timeScale * speedScale;
			speedTime = speedTime + 10;
			}
		}

        //score = Time.time - startTime;
        ////yield return new WaitForSeconds(10f);
        //meters.text = score.ToString("f2") + "m";

    }

    public void ReportHigh()
    {
        if (Social.localUser.authenticated)
        {
            int reportedScore = (int)(PlayerPrefs.GetFloat("HighScore") * 100);
            Social.ReportScore(reportedScore, VFGPS.leaderboard_high_score, (bool success) => { Debug.Log("reported score" + success.ToString()); });
        }
        else{
            Debug.Log("Couldn't connect to play services");
        }
    }

    public void UnlockAchievement(string achievementID)
    {if (Social.localUser.authenticated)
        {
            Social.ReportProgress(achievementID, 100.0, (bool success) =>
            {
                Debug.Log("Achievement Unlocked" + success.ToString());
            });
    }else{
            Debug.Log("Couldn't connect to play services");
    }
    }

    public void FixedUpdate(){
	}

	//IEnumerator scoreCount(){
 // //      score = Time.time-startTime;
	//	//yield return new WaitForSeconds (10f);
	//	//meters.text = score.ToString ("f2")+"m";
	//}

}
