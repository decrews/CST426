using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorials : MonoBehaviour {

	Queue<Tutorial> gameTuts;
	Tutorial currentTut;
	public Text tutorialText;
	public Text progressText;

	void Start () {
		// Create a Queue for the game's tutorials
		gameTuts = new Queue<Tutorial> ();

		// Create the tutorial objectives
		gameTuts.Enqueue (new Tutorial ("jump", "Do three jumps!", 3));
		gameTuts.Enqueue (new Tutorial ("shoot", "Shoot three times!", 3));

		// Remove the first tutorial from the queue
		currentTut = gameTuts.Dequeue ();
		tutorialText.text = currentTut.objectiveText;
		progressText.text = currentTut.currentCount + " / " + currentTut.objectiveCount;
	}


	void Update() {
		if (EventQueue.tutorialMessages.Count != 0) {
			CheckTutStatus ();
		}
	}


	void CheckTutStatus() {
		// If the tutorial event queue isn't empty, pull it
		EventMessage currentEvent = EventQueue.tutorialMessages.Dequeue ();

		// Check to see if the message fulfills the objective we're looking for
		if (currentEvent.value == currentTut.objective) {
			// Increase the count of actions
			currentTut.currentCount++;
			progressText.text = currentTut.currentCount + " / " + currentTut.objectiveCount;

			// If the player has performed the action enough times, dequeue the next tutorial
			if (currentTut.currentCount == currentTut.objectiveCount) {

				// Check to see if there are anymore tutorials and dequeue it if there is
				if (gameTuts.Count != 0) {
					currentTut = gameTuts.Dequeue ();

					// Assign the text of the new tutorial to the UI element
					tutorialText.text = currentTut.objectiveText;
					progressText.text = currentTut.currentCount + " / " + currentTut.objectiveCount;
				} 

				// If not, let the player know they're done
				else {
					tutorialText.text = "";
					progressText.text = "All Done";
					Destroy (this);
				}
			}
		}
			
	}

	// Contains the data for each tutorial
	struct Tutorial {
		public string objective;
		public string objectiveText;
		public int objectiveCount;
		public int currentCount;

		public Tutorial(string objective, string objectiveText, int objectiveCount) {
			this.objective = objective;
			this.objectiveText = objectiveText;
			this.objectiveCount = objectiveCount;
			currentCount = 0;
		}
	}
}
