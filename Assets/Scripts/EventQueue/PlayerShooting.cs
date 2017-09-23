using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {
	[SerializeField]
	private GameObject playerBullet;

	
	void Update () {
		if (Input.GetKeyDown(KeyCode.RightControl)) {
			Shoot ();
		}
	}

	void Shoot() {
		// Adding an event for the shoot to send to eventqueue
		// ---------------------------------------------------
		EventQueue.tutorialMessages.Enqueue(new EventMessage("shoot"));
		// ---------------------------------------------------

		if (transform.localScale.x > 0) {
			GameObject blt = Instantiate (playerBullet, transform.position, transform.rotation);
		} else {
			GameObject blt = Instantiate (playerBullet, transform.position, transform.rotation);
			blt.GetComponent<PlayerBullet> ().movingRight = false;;
		}
	}
}
