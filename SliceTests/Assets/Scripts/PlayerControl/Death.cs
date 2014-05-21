using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {
	public int lives;
	public float damage;
	
//	private Vector3 netImpact;

	// Use this for initialization
	void Start () {
		lives = 3;
	}
	
	// Update is called once per frame
	void Update () {
//		netImpact = Vector3.zero;
		if (transform.position.y <= -40) {
			rigidbody.velocity = Vector3.zero;
			Die ();
		}
	}
	
//	void OnCollisionEnter(Collision other) {
//		netImpact = rigidbody.velocity - other.gameObject.rigidbody.velocity;
//		damage = .01f * Vector3.Magnitude(netImpact);
//		GetComponent<Stats>().health -= damage;
//		print ("damage is: " + damage);
//		if (GetComponent<Stats>().health < 0) {
//			rigidbody.velocity *= 5;
//		}
//	}
	
	void Die () {
		if (lives > 1) {
			transform.position = new Vector3 (0, 35, 0);
			rigidbody.velocity = Vector3.zero;
			lives --;
		} else if (lives == 1) {
			lives --;
		}
		
	}
}
