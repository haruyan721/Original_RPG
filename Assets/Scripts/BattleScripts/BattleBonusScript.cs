using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleBonusScript : MonoBehaviour {
	int expBonus;
	int goldBonus;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void BattleBonusGet(){
		switch (PlayerFieldMoveScript.battleEnemy) {
		case 1:
			expBonus = 30;
			goldBonus = 3;
			PlayerStatus.exp += expBonus;
			PlayerStatus.gold += goldBonus;
			break;
		case 2:
			expBonus = 70;
			goldBonus = 5;
			PlayerStatus.exp += expBonus;
			PlayerStatus.gold += goldBonus;
			break;
		}
	}
}
