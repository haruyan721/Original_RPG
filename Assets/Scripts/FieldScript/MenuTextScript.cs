using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuTextScript : MonoBehaviour {
	
	GameObject menuLevelTextWindow;
	GameObject menuHpTextWindow;
	GameObject menuMpTextWindow;
	GameObject menuPowerTextWindow;
	GameObject menuDefenceTextWindow;
	GameObject menuSpeedTextWindow;
	GameObject menuGoldTextWindow;
	Text levelText;
	Text hpText;	
	Text mpText;
	Text powerText;
	Text defenceText;
	Text speedText;
	Text goldText;
	string levelSentence;
	string hpSentence;
	string mpSentence;
	string powerSentence;
	string defenceSentence;
	string speedSentence;
	string goldSentence;


	// Use this for initialization
	void Start () {
		menuLevelTextWindow = GameObject.Find("MenuLevelTextWindow");
		menuHpTextWindow = GameObject.Find("MenuHPTextWindow");
		menuMpTextWindow = GameObject.Find("MenuMPTextWindow");
		menuPowerTextWindow = GameObject.Find("MenuPowerTextWindow");
		menuDefenceTextWindow = GameObject.Find("MenuDefenceTextWindow");
		menuSpeedTextWindow = GameObject.Find("MenuSpeedTextWindow");
		menuGoldTextWindow = GameObject.Find("MenuGoldTextWindow");
		levelText = menuLevelTextWindow.GetComponent<Text> ();
		hpText = menuHpTextWindow.GetComponent<Text> ();
		mpText = menuMpTextWindow.GetComponent<Text> ();
		powerText = menuPowerTextWindow.GetComponent<Text> ();
		defenceText = menuDefenceTextWindow.GetComponent<Text> ();
		speedText = menuSpeedTextWindow.GetComponent<Text> ();
		goldText = menuGoldTextWindow.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		levelSentence = "LV: " + PlayerStatus.level.ToString ();
		hpSentence = "HP: " + PlayerStatus.playerHp.ToString () + " / " + PlayerStatus.maxPlayerHp.ToString ();
		mpSentence = "MP: " + PlayerStatus.playerMp.ToString () + " / " + PlayerStatus.maxPlayerMp.ToString ();
		powerSentence = "Power: " + PlayerStatus.playerPower.ToString ();
		defenceSentence = "Defence: " + PlayerStatus.playerDefense.ToString ();
		speedSentence = "Speed: " + PlayerStatus.playerSpeed.ToString ();
		goldSentence = PlayerStatus.gold.ToString() + "B";
		levelText.text = levelSentence;
		hpText.text = hpSentence;
		mpText.text = mpSentence;
		powerText.text = powerSentence;
		defenceText.text = defenceSentence;
		speedText.text = speedSentence;
		goldText.text = goldSentence;
	}
}
