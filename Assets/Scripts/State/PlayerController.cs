using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour {

	public Rigidbody2D rb;
	public Collider2D col;
	public PlayerState state;
	public SpriteRenderer sr;

	public List<Sprite> playerSprites;

	[SerializeField]
	public float speed;

	[SerializeField]
	public float gravity = 30;

	public bool grounded;

    [Range(0.01f, 5.0f)]
    public float jumpTravel = 1.8f;

    [Range(0.01f, 10.0f)]
    public float jumpSpeed = 6.0f;

    [Range(0.01f, 5.0f)]
    public float curveCutoff = 3.5f;

	public LayerMask groundMask;

	void Start () {
		grounded = true;
		rb = GetComponent<Rigidbody2D> ();
		col = GetComponent<BoxCollider2D> ();
		sr = GetComponent<SpriteRenderer> ();

		// Adds the initial state to the player
		state = gameObject.AddComponent(typeof(StandingState)) as StandingState;
		state.enter (this);
	}


	void Update () {
		// Increase the gravity of the player, this never changes so it goes outside the state updates
		rb.AddForce(Vector3.down * gravity * rb.mass); // Add more weight to the player

		state.updateState ();
	}

}
