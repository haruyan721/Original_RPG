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
		PlayerPrefs.SetInt ("hpSaveDate", PlayerStatus.playerHpTank);
		PlayerPrefs.SetInt ("mpSaveDate", PlayerStatus.playerMpTank);
		PlayerPrefs.SetInt ("maxHpSavedate", PlayerStatus.maxPlayerHp);
		PlayerPrefs.SetInt ("maxMpSavedate", PlayerStatus.maxPlayerMp);
		PlayerPrefs.SetInt ("expSaveDate", PlayerStatus.expTank);
		PlayerPrefs.SetInt ("goldSaveDate", PlayerStatus.goldTank);
		PlayerPrefs.SetFloat ("player_XPosSaveDate", this.transform.position.x);
		PlayerPrefs.SetFloat ("player_ZPosSaveDate", this.transform.position.z);
		Debug.Log (PlayerPrefs.GetFloat ("player_XPosSaveDate"));
		Debug.Log (PlayerPrefs.GetFloat ("player_ZPosSaveDate"));

	}
}
