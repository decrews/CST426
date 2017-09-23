using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buffer : MonoBehaviour {

	Image board;
	Texture2D boardTex;
	public int width;
	public int height;
	int buffHeight;

	void Start () {
		this.width = width;
		this.height = height;

		board = GetComponent<Image>();
		boardTex = new Texture2D(width, height, TextureFormat.ARGB32, false);
		Sprite sp = Sprite.Create(boardTex, new Rect(0, 0, width, height), new Vector2(0.5f, 0.5f));
		board.sprite = sp;
	}

	public void DrawLine() {
		for (int x = 0; x < width; x++) {
			if (buffHeight % (height / 4) < (height / 8)) {
				if (x % (width / 4) < (width / 8)) {
					boardTex.SetPixel (x, buffHeight, Color.red);
				}
			} else {
				if (x % (width / 4) > (width / 8)) {
					boardTex.SetPixel (x, buffHeight, Color.red);
				}
			}
		}

		boardTex.Apply ();

		buffHeight += 1;
	}

}
