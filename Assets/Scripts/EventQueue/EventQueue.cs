using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public static class EventQueue {
	public static Queue<EventMessage> tutorialMessages = new Queue<EventMessage>();
}

public struct EventMessage {
	public string value;

	public EventMessage (string value) {
		this.value = value;
	}
}
