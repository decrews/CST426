using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletNoPool : MonoBehaviour {

	float speed;

	void Start() {
		speed = 1 + Random.value * 3f;
	}

	void Update () {
		transform.position = new Vector3 (transform.position.x, transform.position.y + Time.deltaTime * speed, transform.position.z);

		if (transform.position.y > 7) {
			Destroy(gameObject);
			Debug.Log("Destroying bullet");
		}
	}
}
