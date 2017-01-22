using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorOnHover : MonoBehaviour {

	public Texture2D cursorTexture;

	void OnMouseEnter() {
		Cursor.SetCursor (cursorTexture, Vector2.zero, CursorMode.Auto);
	}
	
	// Update is called once per frame
	void OnMouseExit () {
		Cursor.SetCursor (null, Vector2.zero, CursorMode.Auto);
	}

	void OnDestroy() {
		Cursor.SetCursor (null, Vector2.zero, CursorMode.Auto);
	}
}
