using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemManager : MonoBehaviour {
	PlayerMover playermover;

	// Use this for initialization
	void Start () {
		playermover = GetComponent<PlayerMover> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Potion(){
		if (SceneManager.GetActiveScene ().name == "Battle") {
			if (ItemTankScript.potionNum > 0) {
				ItemTankScript.potionNum--;
				PlayerStatus.playerHp += 50;
				if (PlayerStatus.playerHp > PlayerStatus.maxPlayerHp) {
					PlayerStatus.playerHp = PlayerStatus.maxPlayerHp;			
				}
				playermover.playercomandcheck = 1;
			}
		}
		if (SceneManager.GetActiveScene ().name == "Field") {
			ItemTankScript.potionNum--;
			if(ItemTankScript.potionNum > 0){
			PlayerStatus.playerHp += 50;
				if (PlayerStatus.playerHp > PlayerStatus.maxPlayerHp) {
					PlayerStatus.playerHp = PlayerStatus.maxPlayerHp;	
				}
			}
		}
	}
}
