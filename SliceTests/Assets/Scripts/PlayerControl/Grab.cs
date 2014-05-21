using UnityEngine;
using System.Collections;

public class Grab : MonoBehaviour {
	Collider otherObj;
	public Transform myParent;
	private string player;
	private string grab;
	
	void Start() {
		player = myParent.GetComponent<Stats>().title;
		grab = player + "_Grab";
		print (grab);
	}
	
	void OnTriggerEnter(Collider other) {
		print ("Collided");
		otherObj = other;
	}


	void FixedUpdate () {
		SpringJoint holding = GetComponent<SpringJoint> ();
		if (Input.GetButton(grab)) {
			if (holding.connectedBody == null && myParent.GetComponent<StateManager>().isGrabbed == false) {
				holding.connectedBody = otherObj.gameObject.rigidbody;
				myParent.GetComponent<CharacterControls>().maxVelocityChange *= 10;
				otherObj.gameObject.GetComponent<StateManager>().isGrabbed = true;
			}
		} else {
			holding.connectedBody = null;
			otherObj = null;
			myParent.GetComponent<Stats>().UpdateAcceleration();
			otherObj.gameObject.GetComponent<StateManager>().isGrabbed = false;
		}
	}
}