using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckScript : MonoBehaviour {

	PlayerStatus playerStatus;

	// Use this for initialization
	void Start () {
		playerStatus = GetComponent<PlayerStatus> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionStay (Collision col){
		if (col.gameObject.tag == "Rest" && Input.GetKeyDown(KeyCode.P)) {
			Debug.Log ("ok");
			playerStatus.playerHp = PlayerStatus.maxPlayerHp;
			playerStatus.playerMp = PlayerStatus.maxPlayerMp;
			playerStatus.StatusStorageInport ();
		}
	}
}
