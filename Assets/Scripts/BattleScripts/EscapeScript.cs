using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeScript : MonoBehaviour {
	GameObject turnManagement;
	TurnManager turnManager;
	PlayerMover playerMover;
	// Use this for initialization
	void Start () {
		turnManagement = GameObject.Find ("TurnManagement");
		turnManager = turnManagement.GetComponent<TurnManager> ();
		playerMover = GetComponent<PlayerMover> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Escape(){
		if (turnManager.playerTurnNum == turnManager.turncount && playerMover.playercomandcheck == 0 && PlayerFieldMoveScript.battleEnemy != 3) {
			playerMover.playercomandcheck = 1;
			turnManager.escapeCheck = 1;
		}
	}
}
