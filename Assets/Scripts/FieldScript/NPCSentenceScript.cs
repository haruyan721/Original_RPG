using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCSentenceScript : MonoBehaviour {
	GameObject talkWindow;
	GameObject talkTextWindow;
	GameObject player;
	//Text talkText;
	string textSentence;
	string npcName;
	int talkCheck;
	PlayerFieldMoveScript playerFieldMoveScript;



	// Use this for initialization
	void Start () {
		npcName = transform.name;
		switch (npcName) {
		case "NPC1":
			textSentence = "こんにちは！";
			break;
		case "NPC2":
			textSentence = "やあ、元気かい？";
			break;
		case "Boss":
			textSentence = "さぁ！かかってくるがよい！";
			break;
		}


		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public string InSentence()
	{
		return textSentence;

	}

	public void NPCTalk(){

		/*if (talkCheck == 0) {
			talkWindow.SetActive (true);
			talkTextWindow = GameObject.Find ("TalkText");
			player = GameObject.Find ("Player");
			Debug.Log (player);
			talkText = talkTextWindow.GetComponent<Text> ();
			playerFieldMoveScript = player.GetComponent<PlayerFieldMoveScript> ();
			npcName = transform.name;
			playerFieldMoveScript.moveStop = 1;
			talkCheck = 1;
			switch (npcName) {
			case "NPC1":
				textSentence = "こんにちは！";
				break;
			case "NPC2":
				textSentence = "やあ、元気かい？";
				break;
			}
			talkText.text = textSentence;
		} else if (talkCheck == 1) {
			playerFieldMoveScript.moveStop = 0;
			talkCheck = 0;
			talkWindow.SetActive (false);
			talkText = null;
		}
	}*/
	}

}
