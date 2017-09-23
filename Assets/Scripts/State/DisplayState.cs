using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayState : MonoBehaviour {

	PlayerController player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.state.GetType() == typeof(JumpingState)) {
			gameObject.GetComponent<Text> ().text = "In the Jumping State";
		} else if (player.state.GetType() == typeof(RunningState)) {
			gameObject.GetComponent<Text> ().text = "In the Running State";
		} else if (player.state.GetType() == typeof(StandingState)) {
			gameObject.GetComponent<Text> ().text = "In the Standing State";
		}
	}
}
