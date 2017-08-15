using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopBuyCheck : MonoBehaviour {
	GameObject buyCheckFade;
	GameObject buyThingText;
	GameObject player;
	Text buyThingSentence;
	public int buyCheckPopUp = 0;
	int price;
	string nameCheck;
	string buyThingName;
	CheckScript checkScript;
	// Use this for initialization
	void Start () {
		buyCheckFade = GameObject.Find ("BuyCheckFade");
		buyThingText = GameObject.Find ("BuyThingText");
		player = GameObject.Find ("Player");
		buyThingSentence = buyThingText.GetComponent<Text> ();
		checkScript = player.GetComponent<CheckScript> ();
		nameCheck = transform.name;
		switch (nameCheck) {
		case "PotionBuy":
			buyThingName = "Potion";
			price = 12;
			break;
		}
		buyCheckFade.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void BuyCheck(){
		if (price < PlayerStatus.gold) {
			if (buyCheckPopUp == 0) {
				buyThingSentence.text = buyThingName;
				buyCheckPopUp = 1;
				buyCheckFade.SetActive (true);
			} else if (buyCheckPopUp == 1) {
				buyCheckPopUp = 0;
				buyCheckFade.SetActive (false);
			}
		}else if(price > PlayerStatus.gold){
			checkScript.talkText.text = "お金が足りません…。";
		}
	}

	public void Buy(){
		PlayerStatus.gold -= price;
		ItemTankScript.potionNum++;
		BuyCheck ();
	}

	public void DontBuy(){
		BuyCheck ();
	}
}
