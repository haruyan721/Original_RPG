using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerStatus.exp >= PlayerStatus.level * 50) {
			Debug.Log ("LevelUp!");
			PlayerStatus.exp = 0;
			PlayerStatus.level++;
			PlayerStatus.maxPlayerHp += 5;
			PlayerStatus.maxPlayerMp += 3;
			PlayerStatus.playerPower += 3;
			PlayerStatus.playerDefense += 2;
			PlayerStatus.playerSpeed += 1;
		}
	}
}
