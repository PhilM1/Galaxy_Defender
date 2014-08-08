using UnityEngine;
using System.Collections;

public class SplashSounds : MonoBehaviour {

	public AudioClip voice;
	public AudioClip start;
	bool hasPlayed = false;
	float timer = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(timer > 2 && hasPlayed == false)
		{
			audio.PlayOneShot(voice);
			hasPlayed = true;
		}
	
	}
}
