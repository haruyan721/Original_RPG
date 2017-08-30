using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestCheckScript : MonoBehaviour {
	GameObject player;
	PlayerFieldMoveScript playerFieldMoveScript;
	WindowPopDownSoundScript popSound;
	GameObject noMoneyText;
	AudioSource audio;
	public AudioClip restSound;
	int restPopUpCheck;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		noMoneyText = GameObject.Find ("NoMoneyText");
		audio = player.GetComponent<AudioSource> ();
		playerFieldMoveScript = player.GetComponent<PlayerFieldMoveScript> ();
		popSound = player.GetComponent<WindowPopDownSoundScript> ();
		this.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void RestCheck(){
		if (restPopUpCheck == 0) {
			popSound.PopUpSound ();
		}
		restPopUpCheck = 1;
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
			audio.PlayOneShot (restSound);

		} else if (PlayerStatus.gold < 8) {
			popSound.PopDownSound ();
			noMoneyText.SetActive (true);
		}
	}
	public void DontRest(){
		popSound.PopDownSound ();
		restPopUpCheck = 0;
		noMoneyText.SetActive (false);
		playerFieldMoveScript.moveStop = 0;
		this.gameObject.SetActive (false);
	}
}
