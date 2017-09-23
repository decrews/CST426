using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState : MonoBehaviour {

	public abstract void updateState ();
	public abstract void enter (PlayerController pc);
}
