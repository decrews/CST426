using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	// You could load data from a text file to create these:
	Breed spider = new Breed ("Spider", 0, 200f);

	void Start () {

		// Creating an instance of the spider from the Type Object
		GameObject spiderOne = spider.createMonster();
		spiderOne.transform.position = new Vector3 (-5, -2, 0);

		// Making a second from the Type Object and giving it a different position.
		// Both have the same basic attributes
		GameObject spiderTwo = spider.createMonster();
		spiderTwo.transform.position = new Vector3 (-8, -2, 0);
	}

	void Update () {
		
	}
}
