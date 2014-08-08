using UnityEngine;
using System.Collections;

public class SplashText : MonoBehaviour {

	SpriteRenderer sr;
	float initYPos;
	int wobbleDir = 1;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();
		initYPos = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
	

		Resize();
		Wobble();


	}


	//Positions the sprite on the screen.
	void Wobble()
	{
		float speed = 0.2f;
		float bounds = 0.1f;
		transform.position = new Vector2(0 , transform.position.y + speed * wobbleDir * Time.deltaTime);
		if(transform.position.y > initYPos + bounds)
		{
			wobbleDir *= -1;
			transform.position = new Vector2(0 , initYPos + bounds);
		}
		else if(transform.position.y < initYPos - bounds)
		{
			wobbleDir *= -1;
			transform.position = new Vector2(0 , initYPos - bounds);
		}
	}

	//resizes the background image based on the camera size.
	void Resize()
	{
		float screenHeight = Camera.main.orthographicSize * 2.0f;
		float screenWidth = screenHeight / Screen.height * Screen.width;
		float scale = screenWidth / sr.sprite.bounds.size.x;
		scale = scale * 0.75f;
		transform.localScale = new Vector3(scale,scale,1);
	}
}
