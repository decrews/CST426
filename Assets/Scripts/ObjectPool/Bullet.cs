using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	float speed;

	void Start() {
		speed = 1 + Random.value * 3f;
	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x, transform.position.y + Time.deltaTime * speed, transform.position.z);

		if (transform.position.y > 7) {
			// Despawn (disable) the bullet once it goes off screen 
			gameObject.SetActive (false);
		}
	}
}
