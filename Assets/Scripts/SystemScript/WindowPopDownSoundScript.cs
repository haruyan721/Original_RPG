using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowPopDownSoundScript : MonoBehaviour {
	AudioSource audio;
	public AudioClip WindowPopUp;
	public AudioClip WindowPopDown;
	public AudioClip yesSound;
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void PopUpSound(){
		audio.PlayOneShot (WindowPopUp);
	}
	public void PopDownSound(){
		audio.PlayOneShot (WindowPopDown);
	}
	public void Yes(){
		audio.PlayOneShot (yesSound);
	}
}
