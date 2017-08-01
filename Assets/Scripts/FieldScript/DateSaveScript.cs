using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateSaveScript : MonoBehaviour {


	// Use this for initialization
	void Start () {
		//PlayerPrefs.DeleteKey("saveCheck");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.M)) {
			PlayerPrefs.DeleteAll ();
		}
	}

	public void Save(){
		Debug.Log ("ok");
		PlayerPrefs.SetInt ("saveCheck", 1);
		PlayerPrefs.SetInt ("levelSaveDate", PlayerStatus.level);
		PlayerPrefs.SetInt ("hpSaveDate", PlayerStatus.playerHp);
		PlayerPrefs.SetInt ("mpSaveDate", PlayerStatus.playerMp);
		PlayerPrefs.SetInt ("maxHpSaveDate", PlayerStatus.maxPlayerHp);
		PlayerPrefs.SetInt ("maxMpSaveDate", PlayerStatus.maxPlayerMp);
		PlayerPrefs.SetInt ("powerSaveDate", PlayerStatus.playerPower);
		PlayerPrefs.SetInt ("defenseSaveDate", PlayerStatus.playerDefense);
		PlayerPrefs.SetInt ("speedSaveDate", PlayerStatus.playerSpeed);
		PlayerPrefs.SetInt ("expSaveDate", PlayerStatus.exp);
		PlayerPrefs.SetInt ("goldSaveDate", PlayerStatus.gold);
		PlayerPrefs.SetFloat ("player_XPosSaveDate", this.transform.position.x);
		PlayerPrefs.SetFloat ("player_ZPosSaveDate", this.transform.position.z);

	}
}
