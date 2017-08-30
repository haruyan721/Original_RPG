using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartOperationWindowScript : MonoBehaviour {
	GameObject operaImage1;
	GameObject operaImage2;
	GameObject operaImage3;
	GameObject operaImage4;
	GameObject fieldOperaText;
	GameObject menuOperaText;
	GameObject battleOperaText;
	GameObject fieldText;
	GameObject menuText;
	GameObject battleText;
	GameObject windowChangeRight;
	GameObject windowChangeLeft;
	WindowPopDownSoundScript popSound;
	public int OperaNum;
	// Use this for initialization
	void Awake(){
		operaImage1 = GameObject.Find ("OperaImage1");
		operaImage2 = GameObject.Find ("OperaImage2");
		operaImage3 = GameObject.Find ("OperaImage3");
		operaImage4 = GameObject.Find ("OperaImage4");
		fieldOperaText = GameObject.Find("FieldOperaText");
		menuOperaText = GameObject.Find("MenuOperaText");
		battleOperaText = GameObject.Find("BattleOperaText");
		fieldText = GameObject.Find ("FieldText");
		menuText = GameObject.Find ("MenuText");
		battleText = GameObject.Find ("BattleText");
		windowChangeRight = GameObject.Find ("WindowChangeRight");
		windowChangeLeft = GameObject.Find ("WindowChangeLeft");
		popSound = GetComponent<WindowPopDownSoundScript> ();
		OperaNum = 1;
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		switch (OperaNum) {
		case 1:
			operaImage1.SetActive (true);
			operaImage2.SetActive (true);
			operaImage3.SetActive (false);
			operaImage4.SetActive (false);
			fieldOperaText.SetActive (true);
			menuOperaText.SetActive (false);
			battleOperaText.SetActive (false);
			fieldText.SetActive (true);
			menuText.SetActive (false);
			battleText.SetActive (false);
			windowChangeRight.SetActive (true);
			windowChangeLeft.SetActive (false);
			break;
		case 2:
			operaImage1.SetActive (false);
			operaImage2.SetActive (false);
			operaImage3.SetActive (true);
			operaImage4.SetActive (false);
			fieldOperaText.SetActive (false);
			menuOperaText.SetActive (true);
			battleOperaText.SetActive (false);
			fieldText.SetActive (false);
			menuText.SetActive (true);
			battleText.SetActive (false);
			windowChangeRight.SetActive (true);
			windowChangeLeft.SetActive (true);
			break;
		case 3:
			operaImage1.SetActive (false);
			operaImage2.SetActive (false);
			operaImage3.SetActive (false);
			operaImage4.SetActive (true);
			fieldOperaText.SetActive (false);
			menuOperaText.SetActive (false);
			battleOperaText.SetActive (true);
			fieldText.SetActive (false);
			menuText.SetActive (false);
			battleText.SetActive (true);
			windowChangeRight.SetActive (false);
			windowChangeLeft.SetActive (true);
			break;
		}
	}

	public void ChangeRight(){
		popSound.PopUpSound ();
		OperaNum++;
	}
	public void ChangeLeft(){
		popSound.PopUpSound ();
		OperaNum--;
	}
}
