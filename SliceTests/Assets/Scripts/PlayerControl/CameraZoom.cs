using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {

// a more efficient version of this would only be called upon movement of the scroll wheel.
	
	public Transform myParent;
	private float zoomLevel = -1.8f;
	private string player;
	private string zoom;
	
	void Start() {
		player = myParent.GetComponent<Stats>().title;
		zoom = player + "_Zoom";
	}

	void Update () {
		// change zoom level based upon movement of the scroll wheel
		zoomLevel += (Input.GetAxis (zoom))*.1f;
		// if the zoom level is in front of the player, reset it to first person view
		if (zoomLevel >= 0) {
			zoomLevel = 0f;
		}
		// make zoom level the distance between the cam and the parent in the z plane
		transform.localPosition = new Vector3(0, transform.localPosition.y, zoomLevel);
	}
}
