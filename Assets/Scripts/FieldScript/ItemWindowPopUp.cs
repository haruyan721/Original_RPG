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
	GameObject tablet;
	GameObject menusPlayer;
	Text potionTextWindow;
	Text tabletTextWindow;
	TurnManager turnManager;
	PlayerMover playerMover;
	WeaponPopUpScript weaponPopUpScript;
	public int itemPopUpCheck;
	string potionNumSentence;
	string tabletNumSentence;
	// Use this for initialization
	void Awake(){
		if (SceneManager.GetActiveScene ().name == "Field") {
			menusPlayer = GameObject.Find ("MenusPlayer");
			potion = GameObject.Find ("MenuPotion");
			tablet = GameObject.Find ("MenuTablet");
			weaponPopUpScript = GetComponent<WeaponPopUpScript>();
			potionTextWindow = potion.GetComponent<Text> ();
			tabletTextWindow = tablet.GetComponent<Text> ();
			itemWindow = GameObject.Find ("ItemWindow");
		}
	}

	void Start () {
		if (SceneManager.GetActiveScene ().name == "Battle") {
			turnManagement = GameObject.Find ("TurnManagement");
			itemWindow = GameObject.Find ("ItemWindow");
			nextButton = GameObject.Find ("Next");
			potion = GameObject.Find ("Potion");
			tablet = GameObject.Find ("Tablet");
			turnManager = turnManagement.GetComponent<TurnManager> ();
			playerMover = GetComponent<PlayerMover> ();
			potionTextWindow = potion.GetComponent<Text> ();
			tabletTextWindow = tablet.GetComponent<Text> ();
			itemWindow.SetActive (false);
		} else if (SceneManager.GetActiveScene ().name == "Field") {
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
			tabletNumSentence = "Tablet : " + ItemTankScript.tabletNum.ToString ();
			tabletTextWindow.text = tabletNumSentence;
			if (ItemTankScript.tabletNum == 0) {
				tablet.SetActive (false);
			}
		}

	}
	public void ItemPopUpDown(){
		if (SceneManager.GetActiveScene ().name == "Battle") {
			if (itemPopUpCheck == 0 && turnManager.turncount == turnManager.playerTurnNum && playerMover.playercomandcheck == 0) {
				if (ItemTankScript.potionNum == 0) {
					potion.SetActive (false);
				}
				if (ItemTankScript.tabletNum == 0) {
					tablet.SetActive (false);
				}
				itemWindow.SetActive (true);
				potionNumSentence = "Potion : " + ItemTankScript.potionNum.ToString ();
				potionTextWindow.text = potionNumSentence;
				tabletNumSentence = "Tablet : " + ItemTankScript.tabletNum.ToString ();
				tabletTextWindow.text = tabletNumSentence;
				nextButton.SetActive (false);
				itemPopUpCheck++;
			} else if (itemPopUpCheck == 1 && turnManager.turncount == turnManager.playerTurnNum && playerMover.playercomandcheck == 0) {
				itemWindow.SetActive (false);
				nextButton.SetActive (true);
				itemPopUpCheck--;
			}
		} else if (SceneManager.GetActiveScene ().name == "Field") {
			if (weaponPopUpScript.weaponPopCheck == 0) {
				if (itemPopUpCheck == 0) {
					menusPlayer.SetActive (false);
					itemWindow.SetActive (true);
					itemPopUpCheck++;
				} else if (itemPopUpCheck == 1) {
					menusPlayer.SetActive (true);
					itemWindow.SetActive (false);
					itemPopUpCheck--;
				}
			}
		}
	}
}
