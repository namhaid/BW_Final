using UnityEngine;
using System.Collections;

public class ToyRespawn : MonoBehaviour {
	public Vector3 SpawnLoc;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y <= -40) {
			Respawn (SpawnLoc);
		}
	}
	
	void Respawn (Vector3 location) {
		transform.position = location;
		rigidbody.velocity = Vector3.zero;
	}
}
