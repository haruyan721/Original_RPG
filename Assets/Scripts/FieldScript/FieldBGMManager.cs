using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldBGMManager : MonoBehaviour {
	AudioSource fieldBGM;
	AudioSource townBGM;
	GameObject player;
	PlayerFieldMoveScript playerFieldMoveScript;
	int bgmCheck;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		playerFieldMoveScript = player.GetComponent<PlayerFieldMoveScript> ();
		AudioSource[] BGMs = GetComponents<AudioSource> ();
		fieldBGM = BGMs [0];
		townBGM = BGMs [1];
		if (playerFieldMoveScript.townMode == 0) {
			bgmCheck = 0;
		} else if (playerFieldMoveScript.townMode == 1) {
			bgmCheck = 1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (bgmCheck == 0 && playerFieldMoveScript.townMode == 0) {
			bgmCheck++;
			fieldBGM.Play ();
			townBGM.Stop ();
		} else if (bgmCheck == 1 && playerFieldMoveScript.townMode == 1) {
			bgmCheck--;
			townBGM.Play ();
			fieldBGM.Stop ();
		}
	}
}
