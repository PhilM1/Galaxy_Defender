using UnityEngine;
using System.Collections;

public class SplashBackground : MonoBehaviour {

	SpriteRenderer sr;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

		Resize();
	}

	//resizes the background image based on the camera size.
	void Resize()
	{
		float screenHeight = Camera.main.orthographicSize * 2.0f;
		float screenWidth = screenHeight / Screen.height * Screen.width;
		float scale = screenWidth / sr.sprite.bounds.size.x;
		transform.localScale = new Vector3(scale,scale,1);
	}
}
