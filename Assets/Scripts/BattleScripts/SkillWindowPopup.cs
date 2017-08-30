using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillWindowPopup : MonoBehaviour {

	GameObject turnManagement;
	GameObject skillButton1;
	GameObject skillButton2;
	GameObject nextButton;
	TurnManager turnManager;
	PlayerMover playerMover;
	WindowPopDownSoundScript popSound;
	public int popUpcheck;

	// Use this for initialization
	void Start () {
		skillButton1 = GameObject.Find ("Skill1");
		skillButton2 = GameObject.Find ("Skill2");
		nextButton = GameObject.Find ("Next");
		turnManagement = GameObject.Find ("TurnManagement");
		turnManager = turnManagement.GetComponent<TurnManager> ();
		playerMover = GetComponent<PlayerMover> ();
		popSound = GetComponent<WindowPopDownSoundScript> ();
		skillButton1.SetActive (false);
		skillButton2.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PopUpDown (){
		if (popUpcheck == 0 && turnManager.turncount == turnManager.playerTurnNum && playerMover.playercomandcheck == 0) {
			popSound.PopUpSound ();
			skillButton1.SetActive (true);
			skillButton2.SetActive (true);
			nextButton.SetActive (false);
			popUpcheck++;
		} else if (popUpcheck == 1 && turnManager.turncount == turnManager.playerTurnNum && playerMover.playercomandcheck == 0){
			skillButton1.SetActive (false);
			skillButton2.SetActive (false);
			nextButton.SetActive (true);
			if (playerMover.playercomandcheck == 0) {
				popSound.PopDownSound ();
			}
			popUpcheck--;
		}
	}
}
