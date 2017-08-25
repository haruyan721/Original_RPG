using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemUser : MonoBehaviour {
	GameObject turnManagemnt;
	AudioSource audio;
	TurnManager turnManager;
	PlayerMover playerMover;
	ItemManager itemManager;
	ItemWindowPopUp itemWindowPopUp;
	PlayerStatus playerStatus;
	public AudioClip healSound;
	// Use this for initialization
	void Start () {
		if (SceneManager.GetActiveScene ().name == "Battle") {
			turnManagemnt = GameObject.Find ("TurnManagement");
			turnManager = turnManagemnt.GetComponent<TurnManager> ();
			playerMover = GetComponent<PlayerMover> ();
			itemWindowPopUp = GetComponent<ItemWindowPopUp> ();
		}
		audio = GetComponent<AudioSource> ();
		itemManager = GetComponent<ItemManager> ();
		playerStatus = GetComponent<PlayerStatus> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void PotionUse(){
		if (playerStatus.noHpMax == 1) {
			if (SceneManager.GetActiveScene ().name == "Battle") {
				if (turnManager.playerTurnNum == turnManager.turncount && playerMover.playercomandcheck == 0) {
					itemWindowPopUp.ItemPopUpDown ();
					itemManager.Potion ();
				}
			}
			if (SceneManager.GetActiveScene ().name == "Field") {
				itemManager.Potion ();
			}
			audio.PlayOneShot (healSound);
		}
	}

	public void TabletUse(){
		if (playerStatus.noMpMax == 1) {
			if (SceneManager.GetActiveScene ().name == "Battle") {
				if (turnManager.playerTurnNum == turnManager.turncount && playerMover.playercomandcheck == 0) {
					itemWindowPopUp.ItemPopUpDown ();
					itemManager.Tablet ();
				}
			}
			if (SceneManager.GetActiveScene ().name == "Field") {
				itemManager.Tablet ();
			}
			audio.PlayOneShot (healSound);
		}

	}
}
