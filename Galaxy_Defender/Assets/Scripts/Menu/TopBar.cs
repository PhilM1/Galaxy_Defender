using UnityEngine;
using System.Collections;

public class TopBar : MonoBehaviour {

    SpriteTransform m_STransform;

	// Use this for initialization
	void Start () {
        m_STransform = GetComponent<SpriteTransform>() as SpriteTransform;

        if( m_STransform != null )
        {
            Resize();
        }        
	}
	
	// Update is called once per frame
	void Update () {

	}

	void Resize()
	{
        //stretch the bar so that it's the length of the screen
        float scaleX = Screen.width / m_STransform.size.x;

        m_STransform.SetScale(scaleX, scaleX);
	}

	void SetPosition()
	{
		//float screenHeight = Camera.main.orthographicSize * 2.0f;
		//transform.position = new Vector2(0,screenHeight / 2 - sr.sprite.bounds.size.y / 2);
	}
}
