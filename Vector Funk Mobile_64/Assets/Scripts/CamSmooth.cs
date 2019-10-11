using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CamSmooth : MonoBehaviour {

	public Transform player;
	public float speed = 0.7f;
	private Vector3 offset;

	void Start ()
	{
		offset = transform.position - player.transform.position;
		//		camRotate = camRotate.GetComponent<Slider> ();
	}

	void FixedUpdate ()
	{
		Vector3 desiredPosition = player.position+offset;
		Vector3 smoothPosition = Vector3.Lerp (transform.position,desiredPosition,speed);
		//transform.position = player.transform.position + offset;
		transform.position = smoothPosition;
		transform.LookAt (player);
		/*if (Input.GetKeyDown ("l")) {
			transform.Rotate (new Vector3 (0,5,0));
		}*/
		if (Input.GetKey ("v")) {
			transform.Rotate (new Vector3 (180, 0, 0)*Time.deltaTime);
		}
	}

	/*public void slider (float newValue){
		transform.Rotate (10, 0, 0) * newValue;

	}*/
}