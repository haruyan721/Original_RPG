using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckScript : MonoBehaviour {
	GameObject talkWindow;
	GameObject talkTextWindow;
	//GameObject player;
	GameObject fadePanel;
	Text talkText;
	NPCSentenceScript npcSentenceScript;
	PlayerFieldMoveScript playerFieldMoveScript;
	FadeManager fadeManager;
	PlayerStatus playerStatus;
	int talkCheck;
	// Use this for initialization
	void Awake(){
		fadePanel = GameObject.Find ("FadePanel");
		fadeManager = fadePanel.GetComponent<FadeManager> ();
	}
	void Start () {
		talkWindow = GameObject.Find ("TalkPanel");
		talkTextWindow = GameObject.Find ("TalkText");
		//player = GameObject.Find ("Player");
		talkText = talkTextWindow.GetComponent<Text> ();
		playerFieldMoveScript = GetComponent<PlayerFieldMoveScript> ();
		playerStatus = GetComponent<PlayerStatus> ();
		talkWindow.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionStay (Collision col){
		if (col.gameObject.tag == "Rest" && Input.GetKeyDown(KeyCode.P) && PlayerStatus.gold >= 8 && playerStatus.noStatusMax == 1) {
			PlayerStatus.playerHp = PlayerStatus.maxPlayerHp;
			PlayerStatus.playerMp = PlayerStatus.maxPlayerMp;
			PlayerStatus.gold -= 8;
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
		if (col.gameObject.tag == "Boss" && Input.GetKeyDown (KeyCode.P)) {
			if (talkCheck == 0) {
				npcSentenceScript = col.gameObject.GetComponent<NPCSentenceScript>();
				talkCheck = 1;
				playerFieldMoveScript.moveStop = 1;
				talkText.text = npcSentenceScript.InSentence ();
				talkWindow.SetActive (true);
			} else if(talkCheck == 1){
				talkCheck = 0;
				PlayerFieldMoveScript.mypos = this.transform.position;
				FadeManager.fadeSpeed = 0.05f;
				PlayerFieldMoveScript.battleEnemy = 3;
				fadePanel.SetActive (true);
				fadeManager.fadeName = "BattleStart";
				fadeManager.changeType = 1;
			}
		}
	}
}
