using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpScript : MonoBehaviour {
	public int levelUpCheck;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (levelUpCheck);
		if (PlayerStatus.exp >= PlayerStatus.level * 50) {
			levelUpCheck = 1;
			Debug.Log ("LevelUp!");
			PlayerStatus.exp = 0;
			PlayerStatus.level++;
			PlayerStatus.maxPlayerHp += 4;
			PlayerStatus.maxPlayerMp += 2;
			PlayerStatus.playerPower += 2;
			PlayerStatus.playerDefense += 1;
			PlayerStatus.playerSpeed += 1;
		}
	}
}
