using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public abstract class Enemy : MonoBehaviour {

	protected float jumpPower;
	protected string className;
	protected Rigidbody2D rb;

	protected void Jump() {
		rb.AddForce (new Vector2 (0, jumpPower));
		Debug.Log (className + " jumping!");
	}
}