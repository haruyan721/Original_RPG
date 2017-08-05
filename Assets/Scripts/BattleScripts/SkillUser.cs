using UnityEngine;
using System.Collections;

public class SkillUser : MonoBehaviour {
	GameObject turnManagemnt;
	TurnManager turnManager;
	PlayerMover playerMover;
	SkillManager skillManager;
	SkillWindowPopup skillWindowPopup;
	public int skillNum;

	// Use this for initialization
	void Start () {
		turnManagemnt = GameObject.Find ("TurnManagement");
		turnManager = turnManagemnt.GetComponent<TurnManager> ();
		playerMover = GetComponent<PlayerMover> ();
		skillManager = GetComponent<SkillManager> ();
		skillWindowPopup = GetComponent<SkillWindowPopup> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SkillButton1(){
		if (turnManager.playerTurnNum == turnManager.turncount && playerMover.playercomandcheck == 0) {
			skillWindowPopup.PopUpDown ();
			skillManager.Flame ();
		}
	}

	public void SkillButton2(){
		if (turnManager.playerTurnNum == turnManager.turncount && playerMover.playercomandcheck == 0) {
			skillWindowPopup.PopUpDown ();
			skillManager.Wind ();
		}
	}
}
