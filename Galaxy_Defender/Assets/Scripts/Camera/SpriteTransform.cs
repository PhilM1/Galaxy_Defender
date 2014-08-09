using UnityEngine;
using System.Collections;

public class SpriteTransform : MonoBehaviour , ICamera2DListener
{
	public bool updateScale = true;

	private Camera2D m_Camera2D = null;

	private Vector2 m_WorldPosition;
	public Vector2 screenPosition;
    public Vector2 spriteScale = Vector2.one;
    public float spriteRotation = 0;
    public Vector2 spriteOrigin = Vector2.zero;

    public Vector2 size = Vector2.zero;
    private Vector3 m_ScaleWithCamera = Vector3.one;

	void OnEnable()
	{
		//-- cache the Camera2D object
		m_Camera2D = Camera.main.gameObject.GetComponent<Camera2D>();
		m_Camera2D.AddListener( this );

        //-- get the sprite information
        SpriteRenderer sr = transform.GetComponent<SpriteRenderer>() as SpriteRenderer;
        if( sr != null )
        {
            //get the original sprite texture size
            size.x = sr.sprite.rect.width;
            size.y = sr.sprite.rect.height;
        }
	}

	void OnDestroy()
	{
		m_Camera2D.RemoveListener( this );
	}

	private void UpdateScale()
	{
        //-- scale with the cameras zoom
        if (m_Camera2D != null)
        {
            if (true == updateScale)
            {
                m_ScaleWithCamera = new Vector3( 1.0f / m_Camera2D.zoom,  1.0f / m_Camera2D.zoom, 1.0f);
            }
            else
            {
                m_ScaleWithCamera = Vector3.one;
            }
        }
		
	}

	void LateUpdate()
	{

	}

	public void Camera2DPostUpdate()
	{
		//-- set the world position by screenspace coordinates
		SetPosition(screenPosition);

        //-- set the actual transform scale
        SetScale(spriteScale);
        
        //-- set rotation
        SetRotation( spriteRotation );

        //-- update the origin
        SetOrigin(spriteOrigin);

        //-- update the scale with the camera zoom change        
        UpdateScale();
	}

    public void SetPosition(Vector2 position)
    {
        //-- use the overloaded (float, float) function
        SetPosition(position.x, position.y);
    }

    public void SetPosition(float x, float y)
    {
        //-- convert desired screen space coordinates to world coordinates
        if (m_Camera2D != null)
        {
            //-- cache the screen space coordinates
            screenPosition.x = x;
            screenPosition.y = y;

            //-- convert screen space to world space
            float wY = (Camera.main.transform.localPosition.y + Camera.main.orthographicSize) - (y / m_Camera2D.pixelsPerUnit / m_Camera2D.zoom);
            float wX = (Camera.main.transform.localPosition.x - (Camera.main.orthographicSize * Camera.main.aspect)) + (x / m_Camera2D.pixelsPerUnit / m_Camera2D.zoom);

            //-- cache the world space coordinates
            m_WorldPosition = new Vector2(wX, wY);
            //-- ste the new world space coordinates
            transform.localPosition = m_WorldPosition;
        }
        else
        {
            //-- can't do calculations withtout Camera2D values
            throw new UnityException("Camera2D not found");
        }
    }

    public void SetScale( Vector2 scale )
    {
        SetScale( scale.x, scale.y );
    }

    public void SetScale( float scaleX, float scaleY )
    {
        spriteScale.x = scaleX;
        spriteScale.y = scaleY;
        //-- multiply in the scale with the camera scaling
        transform.localScale = new Vector3( scaleX * m_ScaleWithCamera.x, scaleY * m_ScaleWithCamera.y, 1.0f );
    }

    public void SetRotation( float rotation )
    {
        spriteRotation = rotation;

        transform.rotation = Quaternion.AngleAxis( rotation, Vector3.back );
    }

    public void SetOrigin( Vector2 origin )
    {
        spriteOrigin = origin;
    }

    public Vector2 getScaledSize()
    {
        Vector2 result = Vector2.zero;
        result.x = size.x * spriteScale.x;
        result.y = size.y * spriteScale.y;
        return result;
    }

    public bool Contains( Vector2 point )
    {
        bool result = false;

        //-- combine scale values from user setting taking into account the camera zoom
        Vector2 multipliedScale = spriteScale;
        if( updateScale != true )
        {
            multipliedScale.x *= m_Camera2D.zoom;
            multipliedScale.y *= m_Camera2D.zoom;
        }

        if (point.x > screenPosition.x && point.x < (screenPosition.x + (size.x * multipliedScale.x)) )
        {
            if (point.y > screenPosition.y && point.y < (screenPosition.y + (size.y * multipliedScale.y)) )
            {
                result = true;
            }
        }

        return result;
    }
}
