using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningState : PlayerState {

	PlayerController player;

	public override void updateState () {
		if (Input.GetKeyDown (KeyCode.Space) && Grounded()) {
			player.state = gameObject.AddComponent(typeof(JumpingState)) as JumpingState;
			player.state.enter (player);
			Destroy (this);
		}

		player.rb.AddForce(Vector3.down * player.gravity * player.rb.mass); // Add more weight to the player
		Move ();
	}


	public override void enter (PlayerController pc) {
		player = pc;
		player.sr.sprite = player.playerSprites [1];
	}


	private void Move() {
		player.rb.velocity = new Vector2 (Input.GetAxis ("Horizontal") * player.speed, player.rb.velocity.y);

		// Switch the player's state from Standing to Running
		if (Input.GetAxis ("Horizontal") == 0) {
			player.state = gameObject.AddComponent (typeof(StandingState)) as StandingState;
			player.state.enter (player);
			Destroy (this);
		} else if (Input.GetAxis ("Horizontal") < 0) {
			transform.localScale = new Vector3 (-1, 1, 1);
		} else if (Input.GetAxis ("Horizontal") > 0) {
			transform.localScale = new Vector3 (1, 1, 1);
		}
	}
		

	private bool Grounded() {
		if (JumpCasts()) {
			// On the ground
			return true;
		} else {
			// In the air
			return false;
		};
	}


	private bool JumpCasts() {
		Vector3[] castPos = new Vector3[] { transform.position, 
			new Vector3 (player.transform.position.x - player.col.bounds.extents.x + 0.1f, player.transform.position.y, player.transform.position.z),
			new Vector3 (player.transform.position.x + player.col.bounds.extents.x - 0.1f, player.transform.position.y, player.transform.position.z)
		};

		bool validJump = false;
		foreach (Vector3 pos in castPos) {
			if (Physics2D.Raycast (pos, Vector2.down, player.col.bounds.extents.y + 0.1f, player.groundMask).collider != null) {
				validJump = true;
			}
		}

		return validJump;
	}
}
