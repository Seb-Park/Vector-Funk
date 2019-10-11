using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Virtual1DJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {


    Image bgImage, joystickImage;
    Vector3 inputVector;
    public PlayerMover player;
    public float maxSpeed, sensitivity;
	// Use this for initialization
	void Start () {
        if(PlayerPrefs.GetInt("controlMethod")!=3)
        {
            gameObject.SetActive(false);
        }
        sensitivity = PlayerPrefs.GetFloat("sensitivity");
        bgImage = GetComponent<Image>();
        joystickImage = transform.GetChild(0).GetComponent<Image>();
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMover>();
        maxSpeed = 20;
	}
	
    public virtual void OnDrag(PointerEventData ped){
        Vector2 pos;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImage.rectTransform,ped.position,ped.pressEventCamera,out pos))
        {
            pos.x = (pos.x / bgImage.rectTransform.sizeDelta.x);
            //pos.y = (pos.y / bgImage.rectTransform.sizeDelta.y) * 2;
            inputVector = new Vector3(Mathf.Clamp(pos.x * 2,-1.0f, 1.0f), 0, pos.y * 2);

            joystickImage.rectTransform.anchoredPosition3D = new Vector3(inputVector.x * (bgImage.rectTransform.sizeDelta.x / 2), 0, 0);
        }
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        inputVector = Vector3.zero;
        joystickImage.rectTransform.anchoredPosition = inputVector;
    }

    // Update is called once per frame
    void FixedUpdate () {
        player.xPos += inputVector.x * Time.fixedDeltaTime * maxSpeed * sensitivity;
	}

    
}
