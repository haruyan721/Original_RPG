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
				PlayerStatus.playerHp += Random.Range(26,33);
				if (PlayerStatus.playerHp > PlayerStatus.maxPlayerHp) {
					PlayerStatus.playerHp = PlayerStatus.maxPlayerHp;			
				}
				playermover.playercomandcheck = 1;
			}
		}
		if (SceneManager.GetActiveScene ().name == "Field") {
			if(ItemTankScript.potionNum > 0){
				ItemTankScript.potionNum--;
				PlayerStatus.playerHp += Random.Range(26,33);
				if (PlayerStatus.playerHp > PlayerStatus.maxPlayerHp) {
					PlayerStatus.playerHp = PlayerStatus.maxPlayerHp;	
				}
			}
		}
	}
	public void Tablet(){
		if (SceneManager.GetActiveScene ().name == "Battle") {
			if (ItemTankScript.tabletNum > 0) {
				ItemTankScript.tabletNum--;
				PlayerStatus.playerMp += Random.Range(8,13);
				if (PlayerStatus.playerMp > PlayerStatus.maxPlayerMp) {
					PlayerStatus.playerMp = PlayerStatus.maxPlayerMp;			
				}
				playermover.playercomandcheck = 1;
			}
		}
		if (SceneManager.GetActiveScene ().name == "Field") {
			if(ItemTankScript.tabletNum > 0){
				ItemTankScript.tabletNum--;
				PlayerStatus.playerMp += Random.Range(8,13);
				if (PlayerStatus.playerMp > PlayerStatus.maxPlayerMp) {
					PlayerStatus.playerMp = PlayerStatus.maxPlayerMp;	
				}
			}
		}
	}
}
