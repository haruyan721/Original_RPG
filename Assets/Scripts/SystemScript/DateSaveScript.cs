﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateSaveScript : MonoBehaviour {
	GameObject player;
	PlayerFieldMoveScript playerFieldMoveScript;
	AudioSource audio;
	public AudioClip savaSound;
	GameObject savepop;

	void Awake(){
		savepop = GameObject.Find ("SaveText");
		savepop.SetActive (false);
	}
	// Use this for initialization
	void Start () {
		//PlayerPrefs.DeleteKey("saveCheck");
		player = GameObject.Find("Player");
		playerFieldMoveScript = player.GetComponent<PlayerFieldMoveScript> ();
		audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		/*if (Input.GetKeyDown (KeyCode.M)) {
			PlayerPrefs.DeleteAll ();
		}*/
	}

	public void Save(){
		audio.PlayOneShot (savaSound);
		PlayerPrefs.SetInt ("saveCheck", 1);
		PlayerPrefs.SetInt ("levelSaveDate", PlayerStatus.level);
		PlayerPrefs.SetInt ("hpSaveDate", PlayerStatus.playerHp);
		PlayerPrefs.SetInt ("mpSaveDate", PlayerStatus.playerMp);
		PlayerPrefs.SetInt ("maxHpSaveDate", PlayerStatus.maxPlayerHp);
		PlayerPrefs.SetInt ("maxMpSaveDate", PlayerStatus.maxPlayerMp);
		PlayerPrefs.SetInt ("powerSaveDate", PlayerStatus.playerPower);
		PlayerPrefs.SetInt ("defenseSaveDate", PlayerStatus.playerDefense);
		PlayerPrefs.SetInt ("speedSaveDate", PlayerStatus.playerSpeed);
		PlayerPrefs.SetInt ("expSaveDate", PlayerStatus.exp);
		PlayerPrefs.SetInt ("goldSaveDate", PlayerStatus.gold);
		PlayerPrefs.SetInt ("potionNumSaveDate", ItemTankScript.potionNum);
		PlayerPrefs.SetInt ("tabletNumSaveDate", ItemTankScript.tabletNum);
		PlayerPrefs.SetInt ("townModeSaveDate", playerFieldMoveScript.townMode);
		PlayerPrefs.SetFloat ("player_XPosSaveDate", this.transform.position.x);
		PlayerPrefs.SetFloat ("player_ZPosSaveDate", this.transform.position.z);
		PlayerPrefs.SetInt ("equWeaponSaveDate", WeaponManager.weaponNum);
		savepop.SetActive (true);
		Invoke ("SavePopDown", 1.5f);
	}

	void SavePopDown(){
		savepop.SetActive (false);
	}
}
