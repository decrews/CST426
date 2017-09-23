using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Enemy {

	void Start () {
		jumpPower = 500f;
		className = "Goblin";
		rb = GetComponent<Rigidbody2D>();
	}

	void OnCollisionEnter2D(Collision2D col) {
		Jump ();
	}
}