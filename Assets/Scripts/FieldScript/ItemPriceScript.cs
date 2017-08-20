using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPriceScript : MonoBehaviour {
	GameObject buyCheckPanel;
	ShopBuyCheck shopBuyCheck;
	public string itemText;
	public int itemPrice;
	// Use this for initialization

	void Awake(){
		buyCheckPanel = GameObject.Find ("BuyCheckPanel");
		shopBuyCheck = buyCheckPanel.GetComponent<ShopBuyCheck> ();
	}
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		switch (shopBuyCheck.buyItemCheck) {
		case 1:
			itemText = "Potion";
			itemPrice = 12;
			break;
		case 2:
			itemText = "Tablet";
			itemPrice = 16;
			break;
		}
	}
}
