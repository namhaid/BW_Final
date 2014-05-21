using UnityEngine;
using System.Collections;

public class WinState : MonoBehaviour {
	public GameObject redPlayer;
	public GameObject greenPlayer;
	public GameObject purplePlayer;
	public GameObject orangePlayer;
	
	private int redScore;
	private int greenScore;
	private int purpleScore;
	private int orangeScore;
	
	private int scoreSum;
	
	// Update is called once per frame
	void Update () {
		redScore = redPlayer.GetComponent<Death>().lives;
		greenScore = greenPlayer.GetComponent<Death>().lives;
		purpleScore = purplePlayer.GetComponent<Death>().lives;
		orangeScore = orangePlayer.GetComponent<Death>().lives;
		
		scoreSum = redScore + greenScore + purpleScore + orangeScore;
		
		if (scoreSum <= redScore) {
			GetComponent<GUIText>().text = "Red Player Wins";
		} else if (scoreSum <= greenScore) {
			GetComponent<GUIText>().text = "Green Player Wins";
		} else if (scoreSum <= purpleScore) {
			GetComponent<GUIText>().text = "Purple Player Wins";
		} else if (scoreSum <= orangeScore) {
			GetComponent<GUIText>().text = "Orange Player Wins";
		} else {
			GetComponent<GUIText>().text = " ";
		}
	}
}
