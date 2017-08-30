using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPopUpScript : MonoBehaviour {
	GameObject player;
	public int weaponPopCheck = 0;
	public int weaponSoundPlayCheck;
	GameObject weaponWindows;
	GameObject menuPlayer;
	ItemWindowPopUp itemWindowPopUp;
	WindowPopDownSoundScript popSound;
	// Use this for initialization

	void Awake(){
		menuPlayer = GameObject.Find ("MenusPlayer");
		weaponWindows = GameObject.Find ("WeaponWindow");
		itemWindowPopUp = GetComponent<ItemWindowPopUp> ();
		popSound = GetComponent<WindowPopDownSoundScript> ();
	}

	void Start () {
		weaponWindows.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void WeaponPopUp(){
		if (weaponPopCheck == 0) {
			if (itemWindowPopUp.itemPopUpCheck == 1) {
				itemWindowPopUp.itemSoundPlayCheck = 1;
				itemWindowPopUp.ItemPopUpDown ();
			}
			popSound.PopUpSound ();
			weaponWindows.SetActive (true);
			menuPlayer.SetActive (false);
			weaponPopCheck++;
		} else if (weaponPopCheck == 1) {
			if (weaponSoundPlayCheck == 0) {
				popSound.PopDownSound ();
			}
			weaponSoundPlayCheck = 0;
			weaponWindows.SetActive (false);
			menuPlayer.SetActive (true);
			weaponPopCheck--;
		}
	}
}
