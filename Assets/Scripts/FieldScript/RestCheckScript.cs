using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestCheckScript : MonoBehaviour {
	GameObject player;
	PlayerFieldMoveScript playerFieldMoveScript;
	GameObject noMoneyText;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		noMoneyText = GameObject.Find ("NoMoneyText");
		playerFieldMoveScript = player.GetComponent<PlayerFieldMoveScript> ();
		this.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void RestCheck(){
		playerFieldMoveScript.moveStop = 1;
		noMoneyText.SetActive (false);
		this.gameObject.SetActive (true);
	}
	public void Rest (){
		if (PlayerStatus.gold >= 8) {
			playerFieldMoveScript.moveStop = 0;
			PlayerStatus.gold -= 8;
			PlayerStatus.playerHp = PlayerStatus.maxPlayerHp;
			PlayerStatus.playerMp = PlayerStatus.maxPlayerMp;
			this.gameObject.SetActive (false);
		} else if (PlayerStatus.gold < 8) {
			noMoneyText.SetActive (true);
		}
	}
	public void DontRest(){
		playerFieldMoveScript.moveStop = 0;
		noMoneyText.SetActive (false);
		this.gameObject.SetActive (false);
	}
}
