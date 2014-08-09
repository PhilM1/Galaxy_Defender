using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum VolumeMenuSpriteIndex
{
    SPRITE_INDEX_BACK = 0,
    SPRITE_INDEX_COUNT
}


public class VolumeMenu : MonoBehaviour, IMenuStateHandler
{
    public Menu_Controller menuController;

    //-- menu elements
    public List<SpriteTransform> sprites;

	// Use this for initialization
	void Start () 
    {
        InitializeMenu();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnGUI()
    {
        int previousFontSize = GUI.skin.label.fontSize;
        GUI.skin.label.fontSize = 100;
        Vector2 textDimensions = GUI.skin.label.CalcSize( new GUIContent("Volume") );
        GUI.Label( new Rect( (Screen.width* 0.5f) - (textDimensions.x * 0.5f), 0, textDimensions.x, 128.0f ), "Volume" );
        GUI.skin.label.fontSize = previousFontSize;
    }

    public void EnableMenu()
    {
        this.transform.gameObject.SetActive( true );

        //-- register input for the quit button
        Button_Back buttonBack = sprites[(int)VolumeMenuSpriteIndex.SPRITE_INDEX_BACK].gameObject.GetComponent<Button_Back>() as Button_Back;
        if (buttonBack != null)
        {
            buttonBack.RegisterInput();
        }
    }

    public void DisableMenu()
    {
        this.transform.gameObject.SetActive( false );

        //-- unregister input for the quit button
        Button_Back buttonBack = sprites[(int)VolumeMenuSpriteIndex.SPRITE_INDEX_BACK].gameObject.GetComponent<Button_Back>() as Button_Back;
        if (buttonBack != null)
        {
            buttonBack.UnregisterInput();
        }
    }

    void InitializeMenu()
    {
        //stretch the bar so that it's the length of the screen
        float spriteScale = Screen.width / 1024.0f;

        int spriteCount = (int)VolumeMenuSpriteIndex.SPRITE_INDEX_COUNT;
        for (int index = 0; index < spriteCount; ++index)
        {
            //-- scale all of the sprites
            if (sprites[index] != null)
            {
                sprites[index].SetScale(spriteScale, spriteScale);
            }
        }

        //-- position the back button
        sprites[(int)VolumeMenuSpriteIndex.SPRITE_INDEX_BACK].SetPosition( Screen.width - sprites[(int)VolumeMenuSpriteIndex.SPRITE_INDEX_BACK].getScaledSize().x, 0 );
    }

    //-- input handlers
    public void GoToMainMenu()
    {
        menuController.Pop();
    }
}
