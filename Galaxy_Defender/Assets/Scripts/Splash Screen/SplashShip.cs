using UnityEngine;
using System.Collections;

public class SplashShip : MonoBehaviour {

	public SpriteRenderer shipRenderer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Resize();
		SetPos();
	}

	void SetPos()
	{
		float screenHeight = Camera.main.orthographicSize * 2.0f;
		transform.position = new Vector2(0,-screenHeight / 4);
	}


	void Resize()
	{
		float screenHeight = Camera.main.orthographicSize * 2.0f;
		float screenWidth = screenHeight / Screen.height * Screen.width;
		float scale = screenWidth / shipRenderer.sprite.bounds.size.x;
		scale = scale * 0.5f;
		transform.localScale = new Vector3(scale,scale,1);
	}
}
