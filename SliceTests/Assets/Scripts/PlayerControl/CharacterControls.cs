using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (CapsuleCollider))]

public class CharacterControls : MonoBehaviour {
	// Inspired by the script originally found on the Unify Community wiki
	// original author unknown.
	// wiki.unity3d.com/index.php?title=RigidbodyFPSWalker

	public float maxSpeed;
	public float gravity = 9.87f;
	public float maxVelocityChange;
	public bool canJump = true;
	public float jumpHeight = 2.0f;
	public bool grounded = true;
	
	public float currentVel;
	
	private string player;
	private string moveX;
	private string moveY;
	private string jump;
	
	private Vector3 velocity;
	
	public float groundedDist = 1f;
	
	
	
	void Awake () {
		rigidbody.freezeRotation = true;
		rigidbody.useGravity = false;
	}
	
	void Start () {
		player = gameObject.GetComponent<Stats>().title;
		moveX = player + "_MoveX";
		moveY = player + "_MoveY";
		jump = player + "_Jump";
	}
	
	void FixedUpdate () {
		// if on the ground
		if (grounded) {
				// if player gives movement input, then move
			if((Input.GetAxis (moveX) > .1) || (Input.GetAxis (moveY) > .1) 
			|| (Input.GetAxis (moveX) > -.1) || (Input.GetAxis (moveY) > -.1)) {
				ActMove(1);
			}
				// if player can jump and presses button, then jump
			if (canJump && Input.GetButton(jump)) {
				ActJump();
			}
			
			// reset grounded to false, forcing it to check every time.
			grounded = false;
		} else if((Input.GetAxis (moveX) > .1) || (Input.GetAxis (moveY) > .1) 
			   || (Input.GetAxis (moveX) > -.1) || (Input.GetAxis (moveY) > -.1)) {
				ActMove(.33f);
		}
		
		// Apply gravity manually for more tuning control
		rigidbody.AddForce(new Vector3 (0, -gravity * rigidbody.mass, 0));
		// for testing purposes, show current velocity
		currentVel = rigidbody.velocity.magnitude;
		
		CheckGrounded ();
	}

	// if touching another collider or rigidbody
	void OnCollisionStay () {
		// CheckGrounded ();
	}
	

	void ActMove (float control) {
		// Calculate how fast we should be moving, and in what direction
			// Get local direction from input
		Vector3 targetVelocity = new Vector3(Input.GetAxis(moveX), 0, Input.GetAxis(moveY));
			// change local direction into world direction
		targetVelocity = transform.TransformDirection(targetVelocity);
		targetVelocity *= maxSpeed;
		
		// Apply a force that attempts to reach our target velocity
			// make velocity = player's current velocity
		velocity = rigidbody.velocity;
			// calculate difference between these two vectors to get how much it needs to change
		Vector3 velocityChange = (targetVelocity - velocity);
			// limit the amount that velocity can change on each axis
		velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
		velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
		velocityChange.y = 0;
			// Add this difference to the player's velocity.
		rigidbody.AddForce(velocityChange * control, ForceMode.Impulse);
	}
	
	void ActJump () {
		// change player's y velocity (see custon function below)
		rigidbody.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
	}
	
	float CalculateJumpVerticalSpeed () {
		// From the jump height and gravity we deduce the upwards speed 
		// for the character to reach at the apex.
		return Mathf.Sqrt(2 * jumpHeight * gravity);
	}
	
	void CheckGrounded () {
		// check if the player is on the ground
		// if size of player changes and this breaks, check the Raycast distance.
		if ( Physics.Raycast (transform.TransformPoint(GetComponent<CapsuleCollider>().center), Vector3.down, (GetComponent<CapsuleCollider>().height)/2)) {
			grounded = true;
		}
	}
}