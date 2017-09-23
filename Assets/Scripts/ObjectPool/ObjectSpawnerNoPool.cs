using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnerNoPool : MonoBehaviour {

	public GameObject prefab;

	// Use this for initialization
	void Start () {
		
	}
	
	void Update () {
		if (Input.GetKey(KeyCode.Space)) {
			Instantiate (prefab, new Vector3 ((Random.value - 0.5f) * 12f, -3.5f, 0f), Quaternion.identity);
		}
	}
}
