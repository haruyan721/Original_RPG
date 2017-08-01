using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckScript : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionStay (Collision col){
		if (col.gameObject.tag == "Rest" && Input.GetKeyDown(KeyCode.P)) {
			PlayerStatus.playerHp = PlayerStatus.maxPlayerHp;
			PlayerStatus.playerMp = PlayerStatus.maxPlayerMp;
		}
	}
}
