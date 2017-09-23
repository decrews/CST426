using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breed : MonoBehaviour {

	public float jumpStrength;
	public string breedName;
	public int spriteImgLoc;

	// Calling the constructor defines what would normally be hardcoded into a class
	public Breed(string bName, int imgLoc, float jStr) {
		jumpStrength = jStr;
		breedName = bName;
		spriteImgLoc = imgLoc;
	}

	public GameObject createMonster() {
		GameObject go = new GameObject (breedName);

		go.AddComponent<SpriteRenderer> ();
		Sprite[] imgs = Resources.LoadAll<Sprite>("TOSprites/");
		go.GetComponent<SpriteRenderer>().sprite = imgs[spriteImgLoc];
		go.GetComponent<SpriteRenderer> ().sortingOrder = 3;
		go.transform.localScale = new Vector3 (6, 6, 1);

		go.AddComponent<BoxCollider2D> ();
		go.AddComponent<Rigidbody2D> ();
		go.GetComponent<Rigidbody2D> ().freezeRotation = true;

		go.AddComponent<Monster> ();
		go.GetComponent<Monster> ().jumpPower = jumpStrength;
		go.GetComponent<Monster> ().className = breedName;
		go.GetComponent<Monster> ().breed = this;

		return go;
	}
}
