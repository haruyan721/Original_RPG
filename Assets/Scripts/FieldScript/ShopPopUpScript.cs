using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPopUpScript : MonoBehaviour {
	public int shopPopUpCheck = 0;
	GameObject shopPanel;
	GameObject player;
	PlayerFieldMoveScript playerFieldMoveScript;
	WindowPopDownSoundScript popSound;
	// Use this for initialization
	void Start () {
		shopPanel = GameObject.Find ("ShopPanel");
		player = GameObject.Find ("Player");
		popSound = player.GetComponent<WindowPopDownSoundScript> ();
		playerFieldMoveScript = player.GetComponent<PlayerFieldMoveScript> ();
		shopPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void ShopPopUP(){
		if (shopPopUpCheck == 0) {
			popSound.PopUpSound ();
			shopPopUpCheck = 1;
			playerFieldMoveScript.moveStop = 1;
			shopPanel.SetActive (true);
		} else if (shopPopUpCheck == 1) {
			popSound.PopDownSound ();
			shopPopUpCheck = 0;
			playerFieldMoveScript.moveStop = 0;
			shopPanel.SetActive (false);
		}
	}
}
