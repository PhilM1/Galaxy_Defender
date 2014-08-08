using UnityEngine;
using System.Collections;

public class Wobble : MonoBehaviour {

	int wobbleDir = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ChangeScale();
	}


	void ChangeScale()
	{
		float speed = 2.0f;
		float bounds = 0.1f;
		transform.localScale = new Vector2(1 , transform.localScale.y + speed * wobbleDir * Time.deltaTime);
		if(transform.localScale.y > 1 + bounds)
		{
			wobbleDir *= -1;
			transform.localScale = new Vector2(1 , 1 + bounds);
		}
		else if(transform.localScale.y < 1 - bounds)
		{
			wobbleDir *= -1;
			transform.localScale = new Vector2(1 , 1 - bounds);
		}
	}
}
