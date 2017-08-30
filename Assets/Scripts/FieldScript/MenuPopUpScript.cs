using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPopUpScript : MonoBehaviour {
	public int popcheck = 0;
	GameObject menuWindows;
	GameObject player;
	GameObject menuButtonText;
	GameObject checkButton;
	Text menuButtonSentence;
	ItemWindowPopUp itemWindoPopUp;
	WeaponPopUpScript weaponPopUpScript;
	PlayerFieldMoveScript playerFieldMoveScript;
	WindowPopDownSoundScript popsound;
	CheckScript checkScript;
	// Use this for initialization
	void Awake(){
		player = GameObject.Find ("Player");
		menuWindows = GameObject.Find ("MenuPanel");
		menuButtonText = GameObject.Find ("MenuButtonText");
		checkButton = GameObject.Find ("CheckButton");
		itemWindoPopUp = player.GetComponent<ItemWindowPopUp> ();
		weaponPopUpScript = player.GetComponent<WeaponPopUpScript> ();
		playerFieldMoveScript = player.GetComponent<PlayerFieldMoveScript> ();
		popsound = player.GetComponent<WindowPopDownSoundScript> ();
		checkScript = player.GetComponent<CheckScript> ();
		menuButtonSentence = menuButtonText.GetComponent<Text> ();

	}
	void Start () {
		menuWindows.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void MenuPop(){
		if (popcheck == 0) {
			checkButton.SetActive (false);
			popsound.PopUpSound ();
			menuWindows.SetActive (true);
			playerFieldMoveScript.moveStop = 1;
			menuButtonSentence.text = "閉じる";
			popcheck = 1;
		} else if (popcheck == 1) {
			if (checkScript.buttonPopCheck == 1) {
				checkButton.SetActive (true);
			}
			popsound.PopDownSound ();
			if (itemWindoPopUp.itemPopUpCheck == 1) {
				itemWindoPopUp.ItemPopUpDown ();
			}
			if (weaponPopUpScript.weaponPopCheck == 1) {
				weaponPopUpScript.WeaponPopUp ();
			}
			menuButtonSentence.text = "メニュー";
			menuWindows.SetActive (false);
			playerFieldMoveScript.moveStop = 0;
			popcheck = 0;
		}
	}
}
