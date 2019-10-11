using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlSlider : MonoBehaviour {

    public Slider slider;
    public PlayerMover player;

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetInt("controlMethod") != 2)
        {
            gameObject.SetActive(false);
        }
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMover>();
        slider.onValueChanged.AddListener((value) => { player.mobileMoveGradient(value); });
	}

}
