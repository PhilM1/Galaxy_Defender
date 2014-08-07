using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface ICamera2DListener
{
	void Camera2DPostUpdate();
}

public class Camera2D : MonoBehaviour {
	
	public float pixelsPerUnit = 100.0f;

	public float zoom = 1.0f;

	public GameObject followTarget = null;
	public bool followSmoothing = false;
	public float followSmoothingAmount = 0.01f;



	private List<ICamera2DListener> m_CameraListeners = new List<ICamera2DListener>();

	public void AddListener(ICamera2DListener listener)
	{
		if( true != m_CameraListeners.Contains(listener) )
		{
			m_CameraListeners.Add( listener );
		}
	}

	public void RemoveListener(ICamera2DListener listener)
	{
		m_CameraListeners.Remove( listener );
	}

	// Use this for initialization
	void Start () {

	}

	void Awake()
	{
		//initial camera zoom 1:1 pixel/unit ratio
		camera.orthographicSize = (Screen.height / pixelsPerUnit / 2.0f) * zoom;

		//set origin at bottom left corner
		camera.transform.position = new Vector3((Screen.width / pixelsPerUnit / 2.0f) * zoom, camera.orthographicSize, -10);
	}

	public Rect GetScreenRect()
	{
		float top = camera.transform.localPosition.y - (Screen.height / pixelsPerUnit * 0.5f);

		Rect rect = new Rect( 0, top, 0, 0 );
		return rect;
	}

	void Update()
	{
		camera.orthographicSize = (Screen.height / pixelsPerUnit / 2.0f) * zoom;

		if(followTarget != null)
		{
			Vector3 target = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, -10);

			if(followSmoothing == true)
			{
				camera.transform.position = Vector3.Lerp(camera.transform.position, target, Mathf.SmoothStep(0f, 1f, followSmoothingAmount * Time.deltaTime));
			}
			else
			{
				camera.transform.position = target;
			}
		}

		//-- post camera update for listeners
		for(int i = 0; i < m_CameraListeners.Count; i++)
		{
			m_CameraListeners[i].Camera2DPostUpdate();
		}
	}
}
