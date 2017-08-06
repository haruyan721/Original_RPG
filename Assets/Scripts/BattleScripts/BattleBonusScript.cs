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
			expBonus = 20;
			goldBonus = 5;
			PlayerStatus.exp += expBonus;
			PlayerStatus.gold += goldBonus;
			break;
		case 2:
			expBonus = 40;
			goldBonus = 10;
			PlayerStatus.exp += expBonus;
			PlayerStatus.gold += goldBonus;
			break;
		}
	}
}
