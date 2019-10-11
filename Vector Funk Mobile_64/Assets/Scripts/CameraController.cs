using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {

	public GameObject player;
	public Slider camRotate;
	private Vector3 offset;
	public Transform playerTransform;

	void Start ()
	{
		offset = transform.position - player.transform.position;
//		camRotate = camRotate.GetComponent<Slider> ();
	}

	void LateUpdate ()
	{
		transform.position = player.transform.position + offset;
//		transform.LookAt (player);
		/*if (Input.GetKey ("v")) {
			transform.Rotate (new Vector3 (0, 180, 0)*Time.deltaTime);
			transform.LookAt (playerTransform);
//			transform.RotateAround (new Vector3 playerTransform,Input.GetAxis("Horizontal"));
		}*/
	}

	/*public void slider (float newValue){
		transform.Rotate (10, 0, 0) * newValue;

	}*/
}