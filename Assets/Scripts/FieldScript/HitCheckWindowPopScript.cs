using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheckWindowPopScript : MonoBehaviour {
	public GameObject hitWindow;
	public AudioClip hitWindowSound;
	AudioSource audio;
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
		hitWindow.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Player") {
			audio.PlayOneShot (hitWindowSound);
			hitWindow.SetActive (true);
		}
	}
	void OnCollisionExit(Collision col){
		if (col.gameObject.tag == "Player") {
			hitWindow.SetActive (false);
		}
	}
}
