using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {
	public Buffer buff;
	public DoubleBuffer doubleBuff;

	void Start () {
		InvokeRepeating ("DrawLine", 0.0f, 0.03f); // Used to slow down the drawing rate.
	}

	void DrawLine() {
		buff.DrawLine ();
		doubleBuff.DrawLine ();

	}
}
