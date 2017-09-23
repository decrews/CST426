using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingState : PlayerState {

	PlayerController player;

	public override void updateState () {
		Move ();
	}
		

	public override void enter (PlayerController pc) {
		player = pc;
		player.sr.sprite = player.playerSprites [2];

		StartCoroutine("JumpCurve");
	}


	private void Move() {
		player.rb.velocity = new Vector2 (Input.GetAxis ("Horizontal") * player.speed, player.rb.velocity.y);
	}


	private IEnumerator JumpCurve()
	{

		float time = (10.0f - player.jumpSpeed) / Mathf.Pow(10.0f, player.jumpTravel);
		float curveVel = player.jumpTravel / time;

		while (Input.GetKey(KeyCode.Space) && curveVel > player.curveCutoff)
		{
			player.rb.velocity = new Vector2(player.rb.velocity.x, curveVel);
			time += Time.deltaTime;
			curveVel = player.jumpTravel / time;
			yield return new WaitForFixedUpdate ();
		}

		player.rb.velocity = new Vector2(player.rb.velocity.x, Vector2.down.y * 0.01f);

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

	void OnCollisionEnter2D(Collision2D col) {
		if (JumpCasts()) {
			// On the ground
			// The player landed, so move back to the standing state
			player.state = gameObject.AddComponent(typeof(StandingState)) as StandingState;
			player.state.enter (player);
			Destroy (this);
		}
	}
}
