using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

	public float jumpPower;
	public string className;
	public Breed breed;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	void OnCollisionEnter2D(Collision2D col) {
		Jump ();
	}

	void Jump() {
		rb.AddForce (new Vector2 (0, breed.jumpStrength));
		Debug.Log (className + " jumping!");
	}
}
