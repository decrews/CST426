using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

	public GameObject prefab;
	public ObjectPool bulletPool;

	void Start () {
		// Create a pool with 100 bullets
		bulletPool = new ObjectPool (prefab, 1000);
		/*
		// Use every bullet in the pool
		for (int i = 0; i < bulletPool.poolSize; i++) {
			bulletPool.GetFromPool (new Vector3((Random.value - 0.5f) * 12f, -3.5f, 0f), Quaternion.identity);
		}
		*/
		InvokeRepeating ("spawnBullet", 0.05f, 0.05f);
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			bulletPool.GetFromPool (new Vector3((Random.value - 0.5f) * 12f, -3.5f, 0f), Quaternion.identity);
		}
	}

	void spawnBullet(){
		bulletPool.GetFromPool (new Vector3 ((Random.value - 0.5f) * 12f, -3.5f, 0f), Quaternion.identity);
	}
}
