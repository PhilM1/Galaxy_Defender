﻿using UnityEngine;
using System.Collections;

public class Button_Achievements : UIButton {

    public MainMenu mainMenu;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void OnClick(TouchEventInfo touchInfo)
    {

        int buttonIndex = (int)MainMenuSpriteIndex.SPRITE_INDEX_ACHIEVEMENTS;
        if (mainMenu.sprites[buttonIndex] != null)
        {
            //-- convert mouse coordinates to use top left as screen origin rather than bottom left
            Vector2 convertedMouseCoordinates = Conversion.ConvertMouseCoordinates(touchInfo.position);

            if (mainMenu.sprites[buttonIndex].Contains(new Vector3(convertedMouseCoordinates.x, convertedMouseCoordinates.y)) == true)
            {
                DebugOut.Instance.AddDebug("tapped achievements");
                mainMenu.GoToAchievements();
            }
        }
    }
}
