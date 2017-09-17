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
	GameObject checkButton;
	GameObject checkButtonText;
	Text checkButtonSentence;
	AudioSource audio;
	public Text talkText;
	public AudioClip windowPopSound;
	public AudioClip windowPopDownSound;
	public int buttonPopCheck;
	NPCSentenceScript npcSentenceScript;
	PlayerFieldMoveScript playerFieldMoveScript;
	FadeManager fadeManager;
	ShopPopUpScript shopPopUpScript;
	//PlayerStatus playerStatus;
	RestCheckScript restCheckScript;
	CheckButtonScript checkButtonScript;
	int talkCheck;
	// Use this for initialization
	void Awake(){
		fadePanel = GameObject.Find ("FadePanel");
		fadeManager = fadePanel.GetComponent<FadeManager> ();
		player = GameObject.Find ("Player");
		shopPopUpScript = player.GetComponent<ShopPopUpScript> ();
		restCheckFade = GameObject.Find ("RestCheckFade");
		restCheckScript = restCheckFade.GetComponent<RestCheckScript> ();
		checkButtonText = GameObject.Find ("CheckButtonText");
		checkButtonSentence = checkButtonText.GetComponent<Text> ();
	}
	void Start () {
		talkWindow = GameObject.Find ("TalkPanel");
		talkTextWindow = GameObject.Find ("TalkText");
		talkText = talkTextWindow.GetComponent<Text> ();
		playerFieldMoveScript = GetComponent<PlayerFieldMoveScript> ();
		//playerStatus = GetComponent<PlayerStatus> ();
		audio = GetComponent<AudioSource>();
		checkButtonScript = GetComponent<CheckButtonScript> ();
		checkButton = GameObject.Find ("CheckButton");
		checkButton.SetActive (false);
		talkWindow.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionStay (Collision col){
		
		if (col.gameObject.tag != "Field") {
			buttonPopCheck = 1;
		}

		if (col.gameObject.tag == "Rest" && checkButtonScript.checkCount == 1 /*&& PlayerStatus.gold >= 8 && playerStatus.noStatusMax == 1*/) {
			restCheckScript.RestCheck ();
			checkButtonScript.checkCount = 0;
		}
		if (col.gameObject.tag == "NPC" && checkButtonScript.checkCount == 1) {
			if (talkCheck == 0) {
				checkButtonSentence.text = "終了";
				talkCheck = 1;
				audio.PlayOneShot (windowPopSound);
				npcSentenceScript = col.gameObject.GetComponent<NPCSentenceScript>();
				playerFieldMoveScript.moveStop = 1;
				talkText.text = npcSentenceScript.InSentence ();
				talkWindow.SetActive (true);
				checkButtonScript.checkCount = 0;
			} else if(talkCheck == 1){
				checkButtonSentence.text = "話す";
				talkCheck = 0;
				audio.PlayOneShot (windowPopDownSound);
				playerFieldMoveScript.moveStop = 0;
				talkWindow.SetActive (false);
				checkButtonScript.checkCount = 0;
			}
		}
		if (col.gameObject.tag == "Boss" && checkButtonScript.checkCount == 1) {
			if (talkCheck == 0) {
				audio.PlayOneShot (windowPopSound);
				checkButtonSentence.text = "戦闘";
				npcSentenceScript = col.gameObject.GetComponent<NPCSentenceScript>();
				talkCheck = 1;
				playerFieldMoveScript.moveStop = 1;
				talkText.text = npcSentenceScript.InSentence ();
				talkWindow.SetActive (true);
				checkButtonScript.checkCount = 0;
			} else if(talkCheck == 1){
				talkCheck = 0;
				PlayerFieldMoveScript.mypos = this.transform.position;
				FadeManager.fadeSpeed = 0.05f;
				PlayerFieldMoveScript.battleEnemy = 3;
				checkButtonScript.checkCount = 0;
				fadePanel.SetActive (true);
				fadeManager.fadeName = "BattleStart";
				fadeManager.changeType = 1;
			}
		}
		if (col.gameObject.tag == "Trader1" && checkButtonScript.checkCount == 1) {
			if (talkCheck == 0 && shopPopUpScript.shopPopUpCheck == 0) {
				npcSentenceScript = col.gameObject.GetComponent<NPCSentenceScript>();
				talkText.text = npcSentenceScript.InSentence ();
				playerFieldMoveScript.moveStop = 1;
				talkCheck = 1;
				talkWindow.SetActive (true);
				shopPopUpScript.ShopPopUP ();
				checkButtonScript.checkCount = 0;
			}
		}
	}
	void OnCollisionExit(Collision col){
		buttonPopCheck = 0;
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
