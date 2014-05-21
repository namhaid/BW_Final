using UnityEngine;
using System.Collections;

public class ScoreGui : MonoBehaviour {
	public GameObject player;
	
	// Update is called once per frame
	void Update () {
		GetComponent<GUIText>().text = player.GetComponent<Death>().lives.ToString();
	
	}
}
