/*using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PlayerController : MonoBehaviour {

	public GameObject BB8;
	public float speed;
	public Text countText;
	public Text winText;
	public GameObject LeiaPicture;
	public Button reset;
	public AudioClip MusicClip;
	public AudioSource MusicSource;
	public AudioSource Death;
	public AudioClip Die;
	public AudioSource Win;
	public AudioClip WinClip;
	private Rigidbody rb;
	private int count;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText ();
		winText.text = "";
		LeiaPicture.gameObject.SetActive (false);
		reset.gameObject.SetActive (false);
		MusicSource.clip = MusicClip;
		Death.clip = Die;
		Win.clip = WinClip;
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ( "Pick Up"))
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
			MusicSource.Play ();
		}

		if (other.gameObject.CompareTag ( "Death"))
		{
			gameObject.SetActive (false);
			BB8.gameObject.SetActive (false);
			winText.text = "You died.";
			reset.gameObject.SetActive (true);
			reset.enabled = true;
			Death.Play();
		}
	}

	void SetCountText ()
	{
		countText.text = "units: " + count.ToString ();
		if (count >= 20)
		{
			Win.Play();
			winText.text = "You Won! The resistence is very proud.";
			LeiaPicture.gameObject.SetActive (true);
			reset.gameObject.SetActive (true);
			reset.enabled = true;
		}
	}
}*/