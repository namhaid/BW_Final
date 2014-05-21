using UnityEngine;
using System.Collections;

public class CameraZoomvV2 : MonoBehaviour {
	
	// a more efficient version of this would only be called upon movement of the scroll wheel.
	
	private float zoomLevel = -7f;
	
	void Update () {
		// change zoom level based upon movement of the scroll wheel
		zoomLevel += Input.GetAxis ("Mouse ScrollWheel");
		// if the zoom level is in front of the player, reset it to first person view
		if (zoomLevel >= 0) {
			zoomLevel = 0f;
		}
		// make zoom level the distance between the cam and the parent in the z plane
		transform.localPosition = new Vector3(0, transform.localPosition.y, zoomLevel);
	}
}
