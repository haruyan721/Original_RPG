using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemWindowPopUp : MonoBehaviour {
	
	GameObject turnManagement;
	GameObject itemWindow;
	GameObject nextButton;
	GameObject potion;
	GameObject menusPlayer;
	Text potionTextWindow;
	TurnManager turnManager;
	PlayerMover playerMover;
	public int itemPopUpCheck;
	string potionNumSentence;
	// Use this for initialization

	void Start () {
		if (SceneManager.GetActiveScene ().name == "Battle") {
			turnManagement = GameObject.Find ("TurnManagement");
			itemWindow = GameObject.Find ("ItemWindow");
			nextButton = GameObject.Find ("Next");
			potion = GameObject.Find ("Potion");
			turnManager = turnManagement.GetComponent<TurnManager> ();
			playerMover = GetComponent<PlayerMover> ();
			potionTextWindow = potion.GetComponent<Text> ();
			itemWindow.SetActive (false);
		} else if (SceneManager.GetActiveScene ().name == "Field") {
			menusPlayer = GameObject.Find ("MenusPlayer");
			itemWindow = GameObject.Find ("ItemWindow");
			potion = GameObject.Find ("MenuPotion");
			potionTextWindow = potion.GetComponent<Text> ();
			itemWindow.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (SceneManager.GetActiveScene ().name == "Field") {
			potionNumSentence = "Potion : " + ItemTankScript.potionNum.ToString ();
			potionTextWindow.text = potionNumSentence;
			if (ItemTankScript.potionNum == 0) {
				potion.SetActive (false);
			}
		}

	}
	public void ItemPopUpDown(){
		if (SceneManager.GetActiveScene ().name == "Battle") {
			if (itemPopUpCheck == 0 && turnManager.turncount == turnManager.playerTurnNum && playerMover.playercomandcheck == 0) {
				if (ItemTankScript.potionNum == 0) {
					potion.SetActive (false);
				}
				itemWindow.SetActive (true);
				string potionNumSentence = "Potion : " + ItemTankScript.potionNum.ToString ();
				potionTextWindow.text = potionNumSentence;
				nextButton.SetActive (false);
				itemPopUpCheck++;
			} else if (itemPopUpCheck == 1 && turnManager.turncount == turnManager.playerTurnNum && playerMover.playercomandcheck == 0) {
				itemWindow.SetActive (false);
				nextButton.SetActive (true);
				itemPopUpCheck--;
			}
		} else if (SceneManager.GetActiveScene ().name == "Field") {
			if(itemPopUpCheck == 0){
				menusPlayer.SetActive (false);
				itemWindow.SetActive (true);
				itemPopUpCheck++;
			}else if(itemPopUpCheck == 1){
				menusPlayer.SetActive (true);
				itemWindow.SetActive (false);
				itemPopUpCheck--;
			}
		}
	}
}
