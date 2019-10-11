using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsMenu : MonoBehaviour {

    public Text title, description;
    public string[] titles, descriptions;
    public int index;
    public Slider sensitivitySlider;

    private void Start()
    {
        if(PlayerPrefs.GetFloat("sensitivity") < 0.1f){
            PlayerPrefs.SetFloat("sensitivity", 0.5f);
        }
        index = PlayerPrefs.GetInt("controlMethod");
        sensitivitySlider.value = PlayerPrefs.GetFloat("sensitivity");
    }
    // Update is called once per frame
    void Update () {
        title.text = titles[index];
        description.text = descriptions[index];
        if(index == 1 || index == 3){
            sensitivitySlider.gameObject.SetActive(true);
        }
        else{
            sensitivitySlider.gameObject.SetActive(false);
        }
    }

    public void SetSensitivity(float input){
        PlayerPrefs.SetFloat("sensitivity", input);
    }

    public void Change(int delta){
        index += delta;
        if(index>=titles.Length){
            index = 0;
        }
        if(index<0){
            index = titles.Length - 1;
        }
        PlayerPrefs.SetInt("controlMethod", index);
    }


}
