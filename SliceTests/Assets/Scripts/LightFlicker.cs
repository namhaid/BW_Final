using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour {

	public float flickerAmount;
	public float flickerPattern;
	
	private float flicker;
	
	// Update is called once per frame
	void Update () {
		flicker = Mathf.PerlinNoise(Time.time * 4, 100 * flickerPattern);
		light.intensity = 1 - (flickerAmount * flicker);	
	}
}
