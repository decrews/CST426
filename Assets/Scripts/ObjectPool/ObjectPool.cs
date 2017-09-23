using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : Pool {

	// Queue of GameObjects to hold and order pool items
	Queue<GameObject> poolItems = new Queue<GameObject> ();

	// Size of the pool
	public int poolSize;

	public ObjectPool(GameObject prefab, int poolSize) {
		CreatePool(prefab, poolSize);
	}

	void CreatePool(GameObject prefab, int poolSize) {
		Debug.Log ("Spawning pool of size: " + poolSize);
		this.poolSize = poolSize;

		// Instantiate and disable pool objects upon creation
		for (int i = 0; i < poolSize; i++) {
			GameObject obj = Instantiate (prefab, Vector3.zero, Quaternion.identity);
			obj.SetActive(false);
			poolItems.Enqueue (obj);
		}
	}

	// Pull an object from the pool by activating it and setting the desired position and rotation
	public void GetFromPool(Vector3 pos, Quaternion rot) {
		// Grab GameObject in the front of the queue
		GameObject obj = poolItems.Dequeue ();

		// Set the GameObject to the requested position
		obj.transform.position = pos;
		obj.transform.rotation = rot;

		// Enable the GameObject
		obj.SetActive(true);

		// Put the GameObject back into the queue for reuse
		poolItems.Enqueue (obj);
	}


}
