using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skele : Enemy {

	void Start () {
		jumpPower = 800f;
		className = "Skeleton";
		rb = GetComponent<Rigidbody2D>();
	}

	void OnCollisionEnter2D(Collision2D col) {
		Jump ();
	}
}