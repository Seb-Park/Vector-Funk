using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerMover : MonoBehaviour {

	public float speed = 10f;
	private Rigidbody rb;
	public bool onGround;
	public float jumpHeight = 300f;
	//public GameObject shield;
	public float hugeJump;
	public GameObject DeathSound;
	public GameObject PowerUpSound;
    public GameObject powerUpEffect;
	public float xPos;
    public GameObject jumpSound;
    public float mobileSpeed = 10, mobileTiltVelocitySpeed, sensitivity;
    public int controlMethod;
    public GameObject controlCanvas;
    float gradientSlerpTarget;


	// Use this for initialization
	void Start () {
        sensitivity = PlayerPrefs.GetFloat("sensitivity");
		rb = GetComponent<Rigidbody>();
		//shield.gameObject.SetActive (false);
		DeathSound.SetActive (false);	
		PowerUpSound.SetActive (false);	
		xPos = 0f;
        controlMethod = PlayerPrefs.GetInt("controlMethod");
        if(controlMethod > 1){
            Instantiate(controlCanvas);
        }
	}
	
	// Update is called once per frame
	void Update(){
        mobileTiltVelocitySpeed = 1;
        if (controlMethod == 0) { 
            mobileMove(); 
        }

        transform.eulerAngles = (new Vector3(0,0,0));
        transform.position = new Vector3(xPos, transform.position.y, -21);
        correctBounds();
    }

    public void mobileMoveGradient(float position){
        gradientSlerpTarget = (position * 10)-5;
    }

    public void mobileMoveGradientSlerping(){
        xPos = Mathf.Lerp(xPos, gradientSlerpTarget, .5f);
    }

    public void correctBounds(){
        if (xPos >= 5 && transform.position.y > 2)
        {
            xPos = 5;
            transform.position = new Vector3(5f, transform.position.y, transform.position.z);
            xPos = 5;
            Debug.Log("making a correction");
        }
        if (xPos <= -5 && transform.position.y > 2)
        {
            xPos = -5;
            transform.position = new Vector3(-5f, transform.position.y, transform.position.z);
            xPos = -5;
            Debug.Log("making a correction");
        }
    }

    public void mobileMove(){
//        Debug.Log(transform.position.y);
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touches.Length; i++)
            {
                Debug.Log(Input.touches[i].position.x);
                if (75 < Input.touches[i].position.x && Input.touches[i].position.x < Screen.width - 100&&Time.timeScale>0)
                {
                    jump();

                }
            }
        }


        //transform.position.y >= 1 &&

        xPos = Mathf.Lerp(xPos, Input.acceleration.x * mobileSpeed, .2f * Time.timeScale);
        //if (xPos >= 5 &&transform.position.y>2)
        //{
        //    transform.position = new Vector3(5f, transform.position.y, transform.position.z);
        //    xPos = 5;
        //    Debug.Log("making a correction");
        //}
        correctBounds();
    }

    public void mobileMoveTiltVelocity()
    {
        //        Debug.Log(transform.position.y);
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touches.Length; i++)
            {
                Debug.Log(Input.touches[i].position.x);
                if (75 < Input.touches[i].position.x && Input.touches[i].position.x < Screen.width - 100 && Time.timeScale > 0)
                {
                    jump();

                }
            }
        }

        if(Mathf.Abs(Input.acceleration.x) > .1) xPos += Input.acceleration.x * sensitivity * 2 * mobileTiltVelocitySpeed;

        correctBounds();
    }

    void FixedUpdate () {
        transform.eulerAngles = (new Vector3(0, 0, 0));
        float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;
		//rb.MovePosition (rb.position + Vector3.right * x);
		xPos += x;
        //float lerpedXposition = Mathf.Lerp(transform.position.x, xPos, .2f);
        //transform.position = new Vector3(lerpedXposition,transform.position.y,-21);
        transform.position = new Vector3(xPos,transform.position.y,-21);
        //Debug.Log("We reached Terminal Velocity" + rb.velocity.y);

        if (rb.velocity.y<-13){
            rb.velocity = new Vector3(rb.velocity.x,-13,rb.velocity.z);
            //Debug.Log("We reached Terminal Velocity"+ rb.velocity.y);
        }

        if (controlMethod == 2){
            mobileMoveGradientSlerping();
        }


        if (Input.GetKey("up")){
            jump();
        }

		if(Input.GetKey("w")&&!Input.GetKey("up")){
            //if(onGround == true){
            //	rb.AddForce(new Vector3 (0,jumpHeight,0));
            //             jumpSound.gameObject.SetActive(true);
            //}
            jump();
		}
        if (controlMethod == 1)
        {
            mobileMoveTiltVelocity();
        }
        else if (controlMethod == 2)
        {
            mobileMoveGradientSlerping();
        }

    }

    public void jump(){
        if (onGround == true)
        {
            rb.AddForce(new Vector3(0, jumpHeight, 0));
            jumpSound.gameObject.SetActive(true);
        }
    }

	void OnCollisionEnter(Collision other) 
	{
		if (other.gameObject.CompareTag ("Gravity"))
		{
			Debug.Log ("RoadGuard");
			other.gameObject.SetActive (false);
			rb.AddForce (new Vector3 (0,-1000,0));
		}
		if (other.gameObject.CompareTag("Block")){
			DeathSound.SetActive (true);
			FindObjectOfType<GameManager>().EndGame();
		}

		if (other.gameObject.CompareTag("Road")){

			PowerUpSound.SetActive (false);	
			onGround=true;
            jumpSound.gameObject.SetActive(false);


        }

        if (other.gameObject.CompareTag ("Jumpguard1")) {
			xPos = 4.7795f;
            //gameObject.transform.position = new Vector3 (4.785f,transform.position.y,transform.position.z);
			Debug.Log ("Hit Right");
		}

		if (other.gameObject.CompareTag ("Jumpguard2")) {
			xPos = -4.7795f;
            //Time.fixedDeltaTime* speed;
            //gameObject.transform.position = new Vector3(-4.785f, transform.position.y, transform.position.z);

            Debug.Log ("Hit Left");
		}


	}
	void OnCollisionExit(Collision road)
	{
		if (road.gameObject.CompareTag ("Road")) {
			onGround = false;
		}
	}

	void OnTriggerEnter(Collider power)
	{
		if (power.gameObject.CompareTag ("Shield")){
			power.gameObject.SetActive (false);
			//shield.gameObject.SetActive (true);
//			Instantiate (shield, transform.position, Quaternion.identity);
			//StartCoroutine( shieldDown ());
		}

		if (power.gameObject.CompareTag ("HugeJump")){
            Instantiate(powerUpEffect, power.gameObject.transform.position, Quaternion.identity);
			power.gameObject.SetActive (false);
			rb.AddForce (new Vector3 (0,hugeJump,0));
			PowerUpSound.SetActive (true);
		}

	}

	IEnumerator shieldDown(){
		yield return new WaitForSeconds (5f);
		//shield.gameObject.SetActive (false);
	}

}