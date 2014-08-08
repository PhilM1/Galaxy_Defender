using UnityEngine;
using System.Collections;

public class testInput : MonoBehaviour {

    public TouchInput touchInput;

    private SpriteRenderer m_SpriteRenderer;

	// Use this for initialization
	void Start () 
    {
        registerTouch();
        m_SpriteRenderer = transform.GetComponent<SpriteRenderer>() as SpriteRenderer;
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}



    public void registerTouch()
    {
        //subscribe to input events
        //TapGestureInput.StateChanged += HandleTapGesture;



        //touchInput.Swipe += SwipeInput;
        touchInput.Tap += TapInput;
        //touchInput.TouchBegan += TouchBeganInput;
        //touchInput.TouchMoved += TouchMovedInput;
        //touchInput.TouchEnded += TouchEndedInput;
        //touchInput.Pinch += PinchInput;

    }

    public void unregisterTouch()
    {
        //unsubscribe to input events


        //touchInput.Swipe -= SwipeInput;
        touchInput.Tap -= TapInput;
        //touchInput.TouchBegan -= TouchBeganInput;
        //touchInput.TouchMoved -= TouchMovedInput;
        //touchInput.TouchEnded -= TouchEndedInput;
        //touchInput.Pinch -= PinchInput;

    }

    void TapInput( TouchEventInfo touchInfo, float deltaTime)
    {
        if (m_SpriteRenderer != null)
        {
            //if( m_SpriteRenderer.bounds.Contains( new Vector3( touchInfo.position.x, touchInfo.position.y ) ) == true )
            {
                DebugOut.Instance.AddDebug("tapped");
            }
        }
    }

}
