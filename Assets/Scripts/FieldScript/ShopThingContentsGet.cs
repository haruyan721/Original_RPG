using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopThingContentsGet : MonoBehaviour {
	string nameCheck;
	string thingName;
	int price;
	// Use this for initialization
	void Start () {
		nameCheck = transform.name;
		switch (nameCheck) {
		case "PotionBuy":
			thingName = "Potion";
			price = 12;
			break;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public string InThingName()
	{
		return thingName;
	}

	public int InPrice()
	{
		return price;
	}
}
