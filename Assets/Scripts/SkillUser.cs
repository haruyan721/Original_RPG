using UnityEngine;
using System.Collections;

public class SkillUser : MonoBehaviour {
	GameObject turnManagemnt;
	TurnManager turnManager;
	PlayerMover playermover;
	SkillManager skillManager;
	SkillWindowPopup skillWindowPopup;
	public int skillNum;

	// Use this for initialization
	void Start () {
		turnManagemnt = GameObject.Find ("TurnManagement");
		turnManager = turnManagemnt.GetComponent<TurnManager> ();
		playermover = GetComponent<PlayerMover> ();
		skillManager = GetComponent<SkillManager> ();
		skillWindowPopup = GetComponent<SkillWindowPopup> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SkillButton1(){
		if (turnManager.playerTurnNum == turnManager.turncount && playermover.playercomandcheck == 0) {
			skillManager.Flame ();
			skillWindowPopup.PopUpDown ();
			playermover.playercomandcheck = 1;
		}
	}
}
