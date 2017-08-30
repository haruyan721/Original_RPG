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
	GameObject potionUseButton;
	GameObject tabletUseButton;
	GameObject potionExpo;
	GameObject tabletExpo;
	GameObject menusPlayer;
	Text potionTextWindow;
	Text tabletTextWindow;
	TurnManager turnManager;
	PlayerMover playerMover;
	WeaponPopUpScript weaponPopUpScript;
	WindowPopDownSoundScript popSound;
	public int itemPopUpCheck;
	public int itemSoundPlayCheck;
	string potionNumSentence;
	string tabletNumSentence;
	// Use this for initialization
	void Awake(){
		potionUseButton = GameObject.Find ("PotionUseButton");
		tabletUseButton = GameObject.Find ("TabletUseButton");
		if (SceneManager.GetActiveScene ().name == "Field") {
			menusPlayer = GameObject.Find ("MenusPlayer");
			potion = GameObject.Find ("MenuPotion");
			tablet = GameObject.Find ("MenuTablet");
			potionExpo = GameObject.Find ("MenuPotionExpo");
			tabletExpo = GameObject.Find ("MenuTabletExpo");
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
		popSound = GetComponent<WindowPopDownSoundScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (SceneManager.GetActiveScene ().name == "Field") {
			potionNumSentence = "ポーション: " + ItemTankScript.potionNum.ToString ();
			potionTextWindow.text = potionNumSentence;
			if (ItemTankScript.potionNum == 0) {
				potion.SetActive (false);
				potionExpo.SetActive (false);
				potionUseButton.SetActive (false);
			}
			tabletNumSentence = "タブレット: " + ItemTankScript.tabletNum.ToString ();
			tabletTextWindow.text = tabletNumSentence;
			if (ItemTankScript.tabletNum == 0) {
				tablet.SetActive (false);
				tabletExpo.SetActive (false);
				tabletUseButton.SetActive (false);
			}
		}

	}
	public void ItemPopUpDown(){
		if (SceneManager.GetActiveScene ().name == "Battle") {
			if (itemPopUpCheck == 0 && turnManager.turncount == turnManager.playerTurnNum && playerMover.playercomandcheck == 0) {
				popSound.PopUpSound ();
				if (ItemTankScript.potionNum == 0) {
					potionUseButton.SetActive (false);
					potion.SetActive (false);
				}
				if (ItemTankScript.tabletNum == 0) {
					tabletUseButton.SetActive (false);
					tablet.SetActive (false);
				}
				itemWindow.SetActive (true);
				potionNumSentence = "ポーション: " + ItemTankScript.potionNum.ToString ();
				potionTextWindow.text = potionNumSentence;
				tabletNumSentence = "タブレット: " + ItemTankScript.tabletNum.ToString ();
				tabletTextWindow.text = tabletNumSentence;
				nextButton.SetActive (false);
				itemPopUpCheck++;
			} else if (itemPopUpCheck == 1 && turnManager.turncount == turnManager.playerTurnNum && playerMover.playercomandcheck == 0) {
				popSound.PopDownSound ();
				itemWindow.SetActive (false);
				nextButton.SetActive (true);
				itemPopUpCheck--;
			}
		} else if (SceneManager.GetActiveScene ().name == "Field") {
				if (itemPopUpCheck == 0) {
					if (weaponPopUpScript.weaponPopCheck == 1) {
						weaponPopUpScript.weaponSoundPlayCheck = 1;
						weaponPopUpScript.WeaponPopUp ();
					}
					popSound.PopUpSound ();
					menusPlayer.SetActive (false);
					itemWindow.SetActive (true);
					itemPopUpCheck++;
				} else if (itemPopUpCheck == 1) {
					if (itemSoundPlayCheck == 0) {
						popSound.PopDownSound ();
					}
					itemSoundPlayCheck = 0;
					menusPlayer.SetActive (true);
					itemWindow.SetActive (false);
					itemPopUpCheck--;
				}
			}
		}
	}
