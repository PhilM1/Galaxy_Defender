using UnityEngine;
using System.Collections;

public class Button_Back : UIButton
{

    public VolumeMenu volumeMenu;

    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void OnClick(TouchEventInfo touchInfo)
    {
        
        int buttonIndex = (int)VolumeMenuSpriteIndex.SPRITE_INDEX_BACK;
        if (volumeMenu.sprites[buttonIndex] != null)
        {
            //-- convert mouse coordinates to use top left as screen origin rather than bottom left
            Vector2 convertedMouseCoordinates = Conversion.ConvertMouseCoordinates(touchInfo.position);

            if (volumeMenu.sprites[buttonIndex].Contains(new Vector3(convertedMouseCoordinates.x, convertedMouseCoordinates.y)) == true)
            {
                DebugOut.Instance.AddDebug("tapped volume");
                volumeMenu.GoToMainMenu();
            }
        }
        
    }
}
