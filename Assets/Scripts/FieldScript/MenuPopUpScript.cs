using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPopUpScript : MonoBehaviour {
	int popcheck = 0;
	GameObject menuWindows;
	GameObject player;
	GameObject itemButton;
	ItemWindowPopUp itemWindoPopUp;
	PlayerFieldMoveScript playerFieldMoveScript;
	// Use this for initialization
	void Awake(){
		player = GameObject.Find ("Player");
		menuWindows = GameObject.Find ("MenuPanel");
		itemButton = GameObject.Find ("ItemButton");
		itemWindoPopUp = itemButton.GetComponent<ItemWindowPopUp> ();
		playerFieldMoveScript = player.GetComponent<PlayerFieldMoveScript> ();

	}
	void Start () {
		menuWindows.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MenuPop(){
		if (popcheck == 0) {
			menuWindows.SetActive (true);
			playerFieldMoveScript.moveStop = 1;
			popcheck = 1;
		} else if (popcheck == 1) {
			if (itemWindoPopUp.itemPopUpCheck == 1) {
				itemWindoPopUp.ItemPopUpDown ();
			}
			menuWindows.SetActive (false);
			playerFieldMoveScript.moveStop = 0;
			popcheck = 0;
		}
	}
}
