using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerModeScript : MonoBehaviour {

	GameObject barCanvas;
	public int playerMode = 0;
	PlayerMover playerMover;
	PlayerHPbarManagement playerHPbarManagement;
	PlayerMPbarManagement playerMPbarManagement;
	PlayerAttacker playerAttacker;
	SkillWindowPopup skillWindowPopup;
	SkillUser skillUser;
	SkillManager skillManager;
	OperationCanvasScript operationCanvasScript;
	PlayerFieldMoveScript playerFieldMoveScript;


	// Use this for initialization
	void Start () {
		barCanvas = GameObject.Find ("Canvas");
		playerMover = GetComponent<PlayerMover> ();
		playerHPbarManagement = GetComponent<PlayerHPbarManagement> ();
		playerMPbarManagement = GetComponent<PlayerMPbarManagement> ();
		playerAttacker = GetComponent<PlayerAttacker> ();
		skillWindowPopup = GetComponent<SkillWindowPopup> ();
		skillUser = GetComponent<SkillUser> ();
		skillManager = GetComponent<SkillManager> ();
		operationCanvasScript = barCanvas.GetComponent<OperationCanvasScript> ();
		playerFieldMoveScript = GetComponent<PlayerFieldMoveScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (SceneManager.GetActiveScene ().name == "Field") {
			
			playerMode = 0;
			playerMover.enabled = false;
			playerHPbarManagement.enabled = false;
			playerMPbarManagement.enabled = false;
			playerAttacker.enabled = false;
			skillWindowPopup.enabled = false;
			skillUser.enabled = false;
			skillManager.enabled = false;
			operationCanvasScript.enabled = false;
			playerFieldMoveScript.enabled = true;

		} else if (SceneManager.GetActiveScene ().name == "Battle"){
			
			playerMode = 1;
			playerMover.enabled = true;
			playerHPbarManagement.enabled = true;
			playerMPbarManagement.enabled = true;
			playerAttacker.enabled = true;
			skillWindowPopup.enabled = true;
			skillUser.enabled = true;
			skillManager.enabled = true;
			operationCanvasScript.enabled = true;
			playerFieldMoveScript.enabled = false;

		}


		
	}
}
