using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPopUpScript : MonoBehaviour {
	public int weaponPopCheck = 0;
	GameObject weaponWindows;
	GameObject menuPlayer;
	ItemWindowPopUp itemWindowPopUp;
	// Use this for initialization

	void Awake(){
		menuPlayer = GameObject.Find ("MenusPlayer");
		weaponWindows = GameObject.Find ("WeaponWindow");
		itemWindowPopUp = GetComponent<ItemWindowPopUp> ();
	}

	void Start () {
		weaponWindows.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void WeaponPopUp(){
		if (itemWindowPopUp.itemPopUpCheck == 0) {
			if (weaponPopCheck == 0) {
				weaponWindows.SetActive (true);
				menuPlayer.SetActive (false);
				weaponPopCheck++;
			} else if (weaponPopCheck == 1) {
				weaponWindows.SetActive (false);
				menuPlayer.SetActive (true);
				weaponPopCheck--;
			}
		}
	}
}
