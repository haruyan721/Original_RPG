using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPopUpScript : MonoBehaviour {
	public int shopPopUpCheck = 0;
	GameObject shopPanel;
	GameObject player;
	PlayerFieldMoveScript playerFieldMoveScript;
	// Use this for initialization
	void Start () {
		shopPanel = GameObject.Find ("ShopPanel");
		player = GameObject.Find ("Player");
		playerFieldMoveScript = player.GetComponent<PlayerFieldMoveScript> ();
		shopPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void ShopPopUP(){
		if (shopPopUpCheck == 0) {
			shopPopUpCheck = 1;
			playerFieldMoveScript.moveStop = 1;
			shopPanel.SetActive (true);
		} else if (shopPopUpCheck == 1) {
			shopPopUpCheck = 0;
			playerFieldMoveScript.moveStop = 0;
			shopPanel.SetActive (false);
		}
	}
}
