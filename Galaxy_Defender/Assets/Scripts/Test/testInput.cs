using UnityEngine;
using System.Collections;

public class testInput : MonoBehaviour {

    public TouchInput touchInput;

    private SpriteRenderer m_SpriteRenderer;
    private SpriteTransform m_STransform;

	// Use this for initialization
	void Start () 
    {
        registerTouch();
        m_SpriteRenderer = transform.GetComponent<SpriteRenderer>() as SpriteRenderer;

        m_STransform = transform.GetComponent<SpriteTransform>() as SpriteTransform;
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
        if (m_STransform != null)
        {
            //-- convert mouse coordinates to use top left as screen origin rather than bottom left
            Vector2 convertedMouseCoordinates = convertMouseCoordinates( touchInfo.position );
            if (m_STransform.Contains(new Vector3(convertedMouseCoordinates.x, convertedMouseCoordinates.y)) == true)
            {
                DebugOut.Instance.AddDebug("tapped sprite");
            }
        }
    }

    //-- converts mouse coordinates from bottom left origin to top left origin
    Vector2 convertMouseCoordinates( Vector2 point )
    {
        Vector2 result = Vector2.zero;

        result.x = point.x;
        result.y = Screen.height - point.y;

        return result;
    }
}
