using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]

public class AudioManager : MonoBehaviour {

	public Sound[] sounds;

	public float volumePercent;

	public Slider volumeSlide;

	public static AudioManager instance;
    public Image muteCover;

	// Use this for initialization
	void Awake () {

		if (instance == null) {
			instance = this;
		} else {
			Destroy (gameObject);
			return;
		}

		DontDestroyOnLoad (gameObject);
		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource> ();
			s.source.clip = s.clip;

			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}
	}

    //public void showSlider(){
    //    volumeSlide.gameObject.SetActive(true);
    //}

    //public void hideSlider()
    //{
    //    volumeSlide.gameObject.SetActive(false);
    //}

    public void toggleMusic(){
        volumePercent = (Mathf.Abs(Mathf.RoundToInt(volumePercent-1))*.5f);
        PlayerPrefs.SetFloat("defaultVol", volumePercent - 1);
        volumeSlide.value = PlayerPrefs.GetFloat("defaultVol") + 1;

    }

    void Start(){
        //PlayerPrefs.SetFloat("defaultVol", 0);
		play ("Music");
        volumePercent = (PlayerPrefs.GetFloat("defaultVol")+1)*.5f;
        volumeSlide.value = PlayerPrefs.GetFloat("defaultVol")+1; 
        SetVolume ("Music", volumePercent);
	}

	void Update(){
		SetVolume ("Music", volumePercent);
        if (volumePercent <= 0)
        {
            muteCover.gameObject.SetActive(true);
        }
        else { muteCover.gameObject.SetActive(false); }

	}
	// Update is called once per frame

	public void play(string name){
		Sound s = Array.Find (sounds, sound=> sound.name ==name);
		s.source.Play ();
	}

	public void SetVolume(string name, float volume){
		Sound s = Array.Find (sounds, sound=> sound.name == name);
		s.source.volume = volume;
	}

	public void getSlider (float volume)
	{
		volumePercent = volume;
        PlayerPrefs.SetFloat("defaultVol",volume-1);
	}


}


