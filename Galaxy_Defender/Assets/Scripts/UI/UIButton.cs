using UnityEngine;
using System.Collections;

public class UIButton : MonoBehaviour {

    public TouchInput touchInput;

    public virtual void OnClick( TouchEventInfo touchInfo ) { }

    public void RegisterInput()
    {
        touchInput.Tap += TapInput;
    }

    public void UnregisterInput()
    {
        touchInput.Tap -= TapInput;
    }

    void TapInput(TouchEventInfo touchInfo, float deltaTime)
    {
        OnClick( touchInfo );
    }
}
