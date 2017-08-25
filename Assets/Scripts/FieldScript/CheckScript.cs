using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckScript : MonoBehaviour {
	GameObject talkWindow;
	GameObject talkTextWindow;
	GameObject player;
	GameObject fadePanel;
	GameObject restCheckFade;
	public Text talkText;
	NPCSentenceScript npcSentenceScript;
	PlayerFieldMoveScript playerFieldMoveScript;
	FadeManager fadeManager;
	ShopPopUpScript shopPopUpScript;
	//PlayerStatus playerStatus;
	RestCheckScript restCheckScript;
	int talkCheck;
	// Use this for initialization
	void Awake(){
		fadePanel = GameObject.Find ("FadePanel");
		fadeManager = fadePanel.GetComponent<FadeManager> ();
		player = GameObject.Find ("Player");
		shopPopUpScript = player.GetComponent<ShopPopUpScript> ();
		restCheckFade = GameObject.Find ("RestCheckFade");
		restCheckScript = restCheckFade.GetComponent<RestCheckScript> ();
	}
	void Start () {
		talkWindow = GameObject.Find ("TalkPanel");
		talkTextWindow = GameObject.Find ("TalkText");
		talkText = talkTextWindow.GetComponent<Text> ();
		playerFieldMoveScript = GetComponent<PlayerFieldMoveScript> ();
		//playerStatus = GetComponent<PlayerStatus> ();
		talkWindow.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionStay (Collision col){
		if (col.gameObject.tag == "Rest" && Input.GetMouseButtonDown(0) /*&& PlayerStatus.gold >= 8 && playerStatus.noStatusMax == 1*/) {
			restCheckScript.RestCheck ();
		}
		if (col.gameObject.tag == "NPC" && Input.GetMouseButtonDown(0)) {
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
		if (col.gameObject.tag == "Boss" && Input.GetMouseButtonDown(0)) {
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
		if (col.gameObject.tag == "Trader1" && Input.GetMouseButtonDown(0)) {
			if (talkCheck == 0 && shopPopUpScript.shopPopUpCheck == 0) {
				npcSentenceScript = col.gameObject.GetComponent<NPCSentenceScript>();
				talkText.text = npcSentenceScript.InSentence ();
				playerFieldMoveScript.moveStop = 1;
				talkCheck = 1;
				talkWindow.SetActive (true);
				shopPopUpScript.ShopPopUP ();
			}
		}
	}

	public void GetNPCTalkSentence(){
		talkText.text = npcSentenceScript.InSentence ();
	}

	public void ShopQuit(){
		talkCheck = 0;
		talkWindow.SetActive (false);
		shopPopUpScript.ShopPopUP ();
	}
}
