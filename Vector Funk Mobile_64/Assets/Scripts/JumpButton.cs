using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JumpButton : MonoBehaviour {

    public Button button;
    public EventTrigger eventTrigger;
    public PlayerMover player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMover>();
        //button.onClick.AddListener(()=> { player.jump(); });
        var pointerDown = new EventTrigger.Entry();
        pointerDown.eventID = EventTriggerType.PointerDown;
        pointerDown.callback.AddListener((e) => { player.jump(); });
        eventTrigger.triggers.Add(pointerDown);
    }

    //public void OnPointerDown(PointerEventData data){
    //    player.jump();
    //}

    // Update is called once per frame
    void Update () {
		
	}
}
