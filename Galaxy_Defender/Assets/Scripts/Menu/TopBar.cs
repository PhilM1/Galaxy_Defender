using UnityEngine;
using System.Collections;

public class TopBar : MonoBehaviour {

	SpriteRenderer sr;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

		Resize();
		SetPosition();
	}

	void Resize()
	{
		float screenHeight = Camera.main.orthographicSize * 2.0f;
		float screenWidth = screenHeight / Screen.height * Screen.width;

		//stretch the bar so that it's the length of the screen
		float scaleX = screenWidth / sr.sprite.bounds.size.x;

		//Set the height to be 10% of the screen height.
		float scaleY = screenHeight * 0.2f / sr.sprite.bounds.size.y;
		
		
		transform.localScale = new Vector3(scaleX,scaleY,1);
	}

	void SetPosition()
	{
		float screenHeight = Camera.main.orthographicSize * 2.0f;
		transform.position = new Vector2(0,screenHeight / 2 - sr.sprite.bounds.size.y / 2);
	}
}
