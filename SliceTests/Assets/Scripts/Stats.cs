using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {

	public string title; // only fill in if necessary

	// Using metric. Because it's easier, goddamnit.
	public float weight; // kg
	public float strength; // kg
	public float maxSpeed; // meters
	public float acceleration; // meters
	public float stamina; // no idea. potential joules? how is this stuff measured? Carbs??
	public float health;
	

	void Start () {
		UpdateWeight ();
		UpdateSpeed ();
		UpdateAcceleration ();
	}

	public void UpdateWeight () {
		// sync everything using weight to Stats.cs
			// the rigidbody, if applicable.
		if(gameObject.GetComponent<Rigidbody>()) {
			rigidbody.mass = weight / 100;
		}
	}

	public void UpdateSpeed () {
		// sync everything using weight to Stats.cs
			// the character controller, if applicable.
		if(gameObject.GetComponent<CharacterControls>()) {
			GetComponent<CharacterControls> ().maxSpeed = maxSpeed;
		}
	}

	public void UpdateAcceleration () {
		// sync everything using acceleration to Stats.cs
			// the character controller, if applicable.
		if(gameObject.GetComponent<CharacterControls>()) {
			GetComponent<CharacterControls> ().maxVelocityChange = acceleration;
		}
	}


}
