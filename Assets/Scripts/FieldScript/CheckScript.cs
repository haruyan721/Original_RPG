using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckScript : MonoBehaviour {
	GameObject talkWindow;
	GameObject talkTextWindow;
	GameObject player;
	Text talkText;
	NPCSentenceScript npcSentenceScript;
	PlayerFieldMoveScript playerFieldMoveScript;
	int talkCheck;
	// Use this for initialization
	void Start () {
		talkWindow = GameObject.Find ("TalkPanel");
		talkTextWindow = GameObject.Find ("TalkText");
		player = GameObject.Find ("Player");
		talkText = talkTextWindow.GetComponent<Text> ();
		playerFieldMoveScript = player.GetComponent<PlayerFieldMoveScript> ();
		talkWindow.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionStay (Collision col){
		if (col.gameObject.tag == "Rest" && Input.GetKeyDown(KeyCode.P)) {
			PlayerStatus.playerHp = PlayerStatus.maxPlayerHp;
			PlayerStatus.playerMp = PlayerStatus.maxPlayerMp;
			Debug.Log ("Rest");
		}
		if (col.gameObject.tag == "NPC" && Input.GetKeyDown (KeyCode.P)) {
			if (talkCheck == 0) {
				npcSentenceScript = col.gameObject.GetComponent<NPCSentenceScript>();
				talkCheck = 1;
				playerFieldMoveScript.moveStop = 1;
				talkText.text = npcSentenceScript.InSentence ();
				talkWindow.SetActive (true);
			} else if(talkCheck == 1){
				talkCheck = 0;
				playerFieldMoveScript.moveStop = 0;
				talkWindow.SetActive (false);
			}
		}
	}
}
