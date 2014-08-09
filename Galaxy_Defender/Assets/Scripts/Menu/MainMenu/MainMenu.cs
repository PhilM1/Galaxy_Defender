using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum SpriteIndex
{
    SPRITE_INDEX_TOP_BAR = 0,
    SPRITE_INDEX_DIFFICULTY,
    SPRITE_INDEX_ACHIEVEMENTS,
    SPRITE_INDEX_VOLUME,
    SPRITE_INDEX_QUIT,
    SPRITE_INDEX_COUNT
}

public class MainMenu : MonoBehaviour, IMenuStateHandler
{
    private enum MainMenuStates
    {
        MAIN_MENU_STATE_NONE,
        MAIN_MENU_STATE_IDLE
    }
    
    public Menu_Controller menuController;

    //-- menu elements
    public List<SpriteTransform> sprites;


    //-- state of the menu
    MainMenuStates m_State = MainMenuStates.MAIN_MENU_STATE_NONE;

	// Use this for initialization
	void Start () 
    {
        menuController.Push( this );

        InitializeMenu();
	}

    void OnDestroy()
    {

    }
	
	// Update is called once per frame
	void Update () 
    {
	    switch( m_State )
        {
            case MainMenuStates.MAIN_MENU_STATE_NONE:
                m_State = MainMenuStates.MAIN_MENU_STATE_IDLE;
                break;
            case MainMenuStates.MAIN_MENU_STATE_IDLE:
                break;
                
        }
	}

    public void EnableMenu()
    {
        //-- register input for the difficulty button
        Button_Difficulty buttonDifficulty = sprites[(int)SpriteIndex.SPRITE_INDEX_DIFFICULTY].gameObject.GetComponent<Button_Difficulty>() as Button_Difficulty;
        if( buttonDifficulty != null )
        {
            buttonDifficulty.RegisterInput();
        }

        //-- register input for the quit button
        Button_Quit buttonQuit = sprites[(int)SpriteIndex.SPRITE_INDEX_QUIT].gameObject.GetComponent<Button_Quit>() as Button_Quit;
        if (buttonQuit != null)
        {
            buttonQuit.RegisterInput();
        }

        //-- register input for the volume button
        Button_Volume buttonVolume = sprites[(int)SpriteIndex.SPRITE_INDEX_VOLUME].gameObject.GetComponent<Button_Volume>() as Button_Volume;
        if (buttonVolume != null)
        {
            buttonVolume.RegisterInput();
        }

        //-- register input for the achievement button
        Button_Achievements buttonAchievements = sprites[(int)SpriteIndex.SPRITE_INDEX_ACHIEVEMENTS].gameObject.GetComponent<Button_Achievements>() as Button_Achievements;
        if (buttonAchievements != null)
        {
            buttonAchievements.RegisterInput();
        }
    }

    public void DisableMenu()
    {
        //-- disable this game object
        this.gameObject.SetActive( false );

        //-- unregister input for the difficulty button
        Button_Difficulty buttonDifficulty = sprites[(int)SpriteIndex.SPRITE_INDEX_DIFFICULTY].gameObject.GetComponent<Button_Difficulty>() as Button_Difficulty;
        if( buttonDifficulty != null )
        {
            buttonDifficulty.UnregisterInput();
        }

        //-- unregister input for the quit button
        Button_Quit buttonQuit = sprites[(int)SpriteIndex.SPRITE_INDEX_QUIT].gameObject.GetComponent<Button_Quit>() as Button_Quit;
        if (buttonQuit != null)
        {
            buttonQuit.UnregisterInput();
        }

        //-- unregister input for the volume button
        Button_Volume buttonVolume = sprites[(int)SpriteIndex.SPRITE_INDEX_VOLUME].gameObject.GetComponent<Button_Volume>() as Button_Volume;
        if (buttonVolume != null)
        {
            buttonVolume.UnregisterInput();
        }

        //-- unregister input for the achievement button
        Button_Achievements buttonAchievements = sprites[(int)SpriteIndex.SPRITE_INDEX_ACHIEVEMENTS].gameObject.GetComponent<Button_Achievements>() as Button_Achievements;
        if (buttonAchievements != null)
        {
            buttonAchievements.UnregisterInput();
        }
    }

    void InitializeMenu()
    {
        //stretch the bar so that it's the length of the screen
        float spriteScale = 1.0f;

        int spriteCount = (int)SpriteIndex.SPRITE_INDEX_COUNT;
        for ( int index = 0; index < spriteCount ; ++index )
        {
            //-- scale all of the sprites
            if( sprites[index] != null )
            {
                //-- base scale off of the top bar
                if( index == (int)SpriteIndex.SPRITE_INDEX_TOP_BAR )
                {
                    spriteScale = Screen.width / sprites[index].size.x;
                }

                sprites[index].SetScale( spriteScale, spriteScale );
            }
        }

        //-- position the quit button
        sprites[(int)SpriteIndex.SPRITE_INDEX_QUIT].SetPosition(Screen.width - sprites[(int)SpriteIndex.SPRITE_INDEX_QUIT].getScaledSize().x, 0);
        //-- position the volume button
        sprites[(int)SpriteIndex.SPRITE_INDEX_VOLUME].SetPosition(Screen.width - sprites[(int)SpriteIndex.SPRITE_INDEX_VOLUME].getScaledSize().x * 2.0f, 0);
        //-- position the achievements button
        sprites[(int)SpriteIndex.SPRITE_INDEX_ACHIEVEMENTS].SetPosition(Screen.width - sprites[(int)SpriteIndex.SPRITE_INDEX_ACHIEVEMENTS].getScaledSize().x * 3.0f, 0);
    }


    public void ChangeDifficulty( Button_Difficulty button )
    {

    }
}
