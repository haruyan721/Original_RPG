﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopBuyCheck : MonoBehaviour {
	GameObject buyCheckFade;
	GameObject buyThingText;
	GameObject player;
	//GameObject shopPanel;
	Text buyThingSentence;
	public int buyCheckPopUp = 0;
	int price;
	public int buyItemCheck;
	//string nameCheck;
	string buyThingName;
	CheckScript checkScript;
	WindowPopDownSoundScript popSound;
	// Use this for initialization
	void Start () {
		buyCheckFade = GameObject.Find ("BuyCheckFade");
		buyThingText = GameObject.Find ("BuyThingText");
		player = GameObject.Find ("Player");
		//shopPanel = GameObject.Find ("ShopPanel");
		buyThingSentence = buyThingText.GetComponent<Text> ();
		checkScript = player.GetComponent<CheckScript> ();
		popSound = player.GetComponent<WindowPopDownSoundScript> ();
		/*nameCheck = transform.name;
		switch (nameCheck) {
		case "PotionBuy":
			buyThingName = "Potion";
			price = 12;
			break;
		case "TabletBuy":
			buyThingName = "Tablet";
			price = 16;
			break;
		}*/
		buyCheckFade.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		
		switch (buyItemCheck) {
		case 1:
			buyThingName = "ポーション";
			price = 12;
			break;
		case 2:
			buyThingName = "タブレット";
			price = 16;
			break;
		}
	}

	public void PosionBuy(){
		buyItemCheck = 1;
		Invoke ("BuyCheck", 0.01f);
	}
	public void TabletBuy(){
		buyItemCheck = 2;
		Invoke ("BuyCheck", 0.01f);
	}

	public void BuyCheck(){
		if (price <= PlayerStatus.gold) {
			Debug.Log ("ok");
			if (buyCheckPopUp == 0) {
				popSound.PopUpSound ();
				buyCheckPopUp = 1;
				buyThingSentence.text = buyThingName;
				buyCheckFade.SetActive (true);
			} else if (buyCheckPopUp == 1) {
				buyCheckPopUp = 0;
				buyCheckFade.SetActive (false);
			}
		}else if(price > PlayerStatus.gold){
			popSound.PopDownSound ();
			checkScript.talkText.text = "お金が足りません…。";
		}
	}

	public void Buy(){
		popSound.Yes ();
		switch (buyItemCheck) {
		case 1:
			ItemTankScript.potionNum++;
			break;
		case 2:
			ItemTankScript.tabletNum++;
			break;
		}
		BuyCheck ();
		PlayerStatus.gold -= price;
	}

	public void DontBuy(){
		popSound.PopDownSound ();
		BuyCheck ();
	}
}
