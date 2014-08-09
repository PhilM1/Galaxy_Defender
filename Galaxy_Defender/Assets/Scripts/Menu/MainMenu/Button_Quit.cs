using UnityEngine;
using System.Collections;

public class Button_Quit : UIButton {

    public MainMenu mainMenu;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void OnClick(TouchEventInfo touchInfo)
    {

        int buttonIndex = (int)SpriteIndex.SPRITE_INDEX_QUIT;
        if (mainMenu.sprites[buttonIndex] != null)
        {
            //-- convert mouse coordinates to use top left as screen origin rather than bottom left
            Vector2 convertedMouseCoordinates = Conversion.ConvertMouseCoordinates(touchInfo.position);

            if (mainMenu.sprites[buttonIndex].Contains(new Vector3(convertedMouseCoordinates.x, convertedMouseCoordinates.y)) == true)
            {
                DebugOut.Instance.AddDebug("tapped quit");
            }
        }
    }
}
