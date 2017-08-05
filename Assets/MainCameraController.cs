using UnityEngine;
using System.Collections;

public class MainCameraController : MonoBehaviour {

	private float cameraPanSpeed = 5.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float dt = Time.deltaTime;

		Transform camTransform = gameObject.transform.GetChild(0);

		gameObject.transform.position += Input.GetAxis("Horizontal") * camTransform.right * cameraPanSpeed * dt;
		Vector3 frw = camTransform.forward;
		frw.y = 0.0f;
		frw.Normalize();
		gameObject.transform.position += Input.GetAxis("Vertical") * frw * cameraPanSpeed * dt;

		if (Input.GetButton("Fire3")) {
			camTransform.RotateAround(gameObject.transform.position, camTransform.right, -Input.GetAxis("Mouse Y"));
			camTransform.RotateAround(gameObject.transform.position, gameObject.transform.up, Input.GetAxis("Mouse X"));
		}
	}
}
