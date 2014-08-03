using UnityEngine;
using System.Collections;

public class SwitchToMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
		{
			Application.LoadLevel("Menu");
		}

	
	}
}
