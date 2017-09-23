using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoubleBuffer : MonoBehaviour {

	Image board;
	Texture2D buffTexOne;
	Texture2D buffTexTwo;
	Texture2D currentTex;

	Sprite sp;
	Sprite spTwo;
	int currentSprite;

	public float refreshRate;

	public int width;
	public int height;
	int buffHeight;

	void Start () {
		board = GetComponent<Image>();
		buffTexOne = new Texture2D(width, height, TextureFormat.ARGB32, false);
		buffTexTwo = new Texture2D(width, height, TextureFormat.ARGB32, false);
		currentTex = buffTexOne;

		sp = Sprite.Create(currentTex, new Rect(0, 0, width, height), new Vector2(0.5f, 0.5f));
		board.sprite = sp;
		currentSprite = 1;
	}

	// Draws a single line on the screen to simulate writing into a frame buffer
	public void DrawLine() {
		for (int x = 0; x < width; x++) {
			if (buffHeight % (height / 4) < (height / 8)) {
				if (x % (width / 4) < (width / 8)) {
					buffTexTwo.SetPixel (x, buffHeight, Color.red);
					buffTexOne.SetPixel (x, buffHeight, Color.red);
				}
			} else {
				if (x % (width / 4) > (width / 8)) {
					buffTexTwo.SetPixel (x, buffHeight, Color.red);
					buffTexOne.SetPixel (x, buffHeight, Color.red);
				}
			}
		}

		buffHeight += 1;

		// simulate a monitor refresh rate.  Controls how often the buffers are flipped.
		if (buffHeight % refreshRate == 0) {
			flipSprites ();
		}
	}

	// Switches between the two buffers
	void flipSprites() {
		if (currentSprite == 1) {
			buffTexTwo.Apply ();
			currentTex = buffTexTwo;
			currentSprite = 2;
		} else {
			buffTexOne.Apply ();
			currentTex = buffTexOne;
			currentSprite = 1;
		}
	}

}
