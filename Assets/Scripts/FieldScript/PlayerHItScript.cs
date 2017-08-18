using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHItScript : MonoBehaviour {
	PlayerFieldMoveScript playerFieldMoveScript;
	GameObject fadePanel;
	FadeManager fadeManager;
	// Use this for initialization

	void Awake(){
		fadePanel = GameObject.Find ("FadePanel");
		fadeManager = fadePanel.GetComponent<FadeManager> ();
		playerFieldMoveScript = GetComponent<PlayerFieldMoveScript> ();
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Enemy") {
			playerFieldMoveScript.moveStop = 1;
			PlayerFieldMoveScript.mypos = this.transform.position;
			PlayerFieldMoveScript.battleEnemy = 1;
			FadeManager.fadeSpeed = 0.05f;
			fadeManager.fadeName = "BattleStart"; 
			fadePanel.SetActive (true);
			fadeManager.changeType = 1;
		}
		if (col.gameObject.tag == "Enemy2") {
			playerFieldMoveScript.moveStop = 1;
			PlayerFieldMoveScript.mypos = this.transform.position;
			PlayerFieldMoveScript.battleEnemy = 2;
			FadeManager.fadeSpeed = 0.05f;
			fadeManager.fadeName = "BattleStart"; 
			fadePanel.SetActive (true);
			fadeManager.changeType = 1;
		}
		if (col.gameObject.tag == "Town1In") {
			playerFieldMoveScript.moveStop = 1;
			FadeManager.fadeSpeed = 0.05f;
			fadeManager.movePos = new Vector3 (-35, 0.725f, 0);
			fadeManager.fadeName = "Town1In";
			fadePanel.SetActive (true);
			fadeManager.changeType = 1;
			//playerFieldMoveScript.townMode = 1;
		}
		if (col.gameObject.tag == "Town1Out") {
			playerFieldMoveScript.moveStop = 1;
			FadeManager.fadeSpeed = 0.05f;
			fadeManager.movePos = new Vector3 (-25, 0.725f, 0);
			fadeManager.fadeName = "Town1Out";
			fadePanel.SetActive (true);
			fadeManager.changeType = 1;
			//playerFieldMoveScript.townMode = 0;
		}
	}
}
