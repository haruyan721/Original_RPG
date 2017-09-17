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
			textSentence = "逃げっていうのは 強くなれないけど、時には必要だぜ。";
			break;
		case "NPC2":
			textSentence = "黒い立方体の部下が暴れるから草原に行けねぇよ！";
			break;
		case "NPC3":
			textSentence = "剣より弓の方が遠くから攻撃できるよ！";
			break;
		case "NPC4":
			textSentence = "あなた強そうなんで黒い奴倒してもらえます？僕？無理。";
			break;
		case "NPC5":
			textSentence = "メニューのOPはオブパワー、Bはブロンでお金のことな。";
			break;
		case "NPC6":
			textSentence = "赤い奴には最初は 近づかない方が いいんでねぇか？";
			break;
		case "NPC7":
			textSentence = "黒い奴らは 「やんきー」だな。てかなんだそれ。";
			break;
		case "TraderNPC":
			textSentence = "何を買いますか？";
			break;
		case "Boss":
			textSentence = "草原は俺らが支配した！文句あるなら かかってこいや！";
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

	/*public void NPCTalk(){

		if (talkCheck == 0) {
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
	}
	}*/

}
