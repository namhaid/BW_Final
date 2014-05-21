using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float speed;
	public float acceleration;
	public float currentSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		currentSpeed = rigidbody.velocity.magnitude;
		// if the player is moving at less than maximum speed
		if (currentSpeed <= speed) {
			// allow the player to be controlled
			Move ();
		}

		if (Input.GetKey (KeyCode.Space)) {
			Jump ();
		}
	
	}

	void Jump () {
		rigidbody.AddForce (transform.up * speed, ForceMode.Force);
	}

	void Move () {
		if (Input.GetKey (KeyCode.W)) {
			rigidbody.AddForce (transform.forward * acceleration, ForceMode.Force);
		}
		if (Input.GetKey (KeyCode.S)) {
			rigidbody.AddForce (-transform.forward * acceleration, ForceMode.Force);
		}
		if (Input.GetKey (KeyCode.A)) {
			rigidbody.AddForce (-transform.right * acceleration, ForceMode.Force);
		}
		if (Input.GetKey (KeyCode.D)) {
			rigidbody.AddForce (transform.right * acceleration, ForceMode.Force);
		}
	}
}
