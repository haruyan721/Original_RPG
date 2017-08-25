using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour {
	GameObject player;
	GameObject turnManagement;
	GameObject fadePanel;
	PlayerFieldMoveScript playerFieldMoveScript;
	TurnManager turnManager;
	public static float fadeSpeed = 0.01f;
	float alfa = 0;
	float red,green,blue;
	public int changeType = 0;
	public string fadeName;
	public Vector3 movePos;
	// Use this for initialization

	void Start () {
		red = GetComponent<Image> ().color.r;
		green = GetComponent<Image> ().color.g;
		blue = GetComponent<Image> ().color.b;
		if(SceneManager.GetActiveScene().name == "Battle"){
			alfa = 1;
			turnManagement = GameObject.Find ("TurnManagement");
			turnManager = turnManagement.GetComponent<TurnManager> ();
		}

		if(SceneManager.GetActiveScene ().name == "Field"){
			player = GameObject.Find ("Player");
			playerFieldMoveScript = player.GetComponent<PlayerFieldMoveScript> ();
		}
			
		if (SceneManager.GetActiveScene ().name == "Field") {
			alfa = 1;
			GetComponent<Image> ().color = new Color (red, green, blue, alfa);
		}
		if (SceneManager.GetActiveScene ().name == "GameOver") {
			alfa = 1;
		}
		if (SceneManager.GetActiveScene ().name == "Clear") {
			alfa = 1;
		}
		if (SceneManager.GetActiveScene ().name == "Title") {
			alfa = 1;
		}

	}
	
	// Update is called once per frame
	void Update () {
		switch (changeType) {

		case 1:
			//fadeSpeed = 0.05f;
			GetComponent<Image> ().color = new Color (red, green, blue, alfa);
			alfa += fadeSpeed;
			if (alfa >= 1) {
				switch (fadeName) {

				case "BattleStart":

					changeType = 0;
					fadeSpeed = 0.1f;
					BattleStart ();
					break;

				case "BattleEnd":

					changeType = 0;
					fadeSpeed = 0.1f;
					turnManager.FieldBack ();
					break;

				case "Town1In":
					player.transform.position = movePos;
					fadeSpeed = 0.1f;
					changeType = 2;
					playerFieldMoveScript.townMode = 1;
					break;

				case "Town1Out":
					player.transform.position = movePos;
					fadeSpeed = 0.1f;
					changeType = 2;
					playerFieldMoveScript.townMode = 0;
					break;

				case "GameOver":
					changeType = 0;
					fadeSpeed = 0.1f;
					turnManager.GameOver ();
					break;

				case "Clear":
					changeType = 0;
					fadeSpeed = 0.1f;
					turnManager.Clear ();
					break;

				case "Title":
					changeType = 0;
					fadeSpeed = 0.1f;
					SceneManager.LoadScene ("Title");
					break;
				case "GoField":
					changeType = 0;
					fadeSpeed = 0.1f;
					SceneManager.LoadScene ("Field");
					break;
				}
			}
			break;

		case 2:
			//fadeSpeed = 0.1f;
			GetComponent<Image> ().color = new Color (red, green, blue, alfa);
			alfa -= fadeSpeed;
			if (alfa <= 0) {
				switch (fadeName) {
				case "BattleStart":
					
					changeType = 0;
					turnManager.BattleStart ();
					break;

				case "BattleEnd":
					changeType = 0;
					playerFieldMoveScript.moveStop = 0;
					this.gameObject.SetActive (false);
					break;

				case "Town1In":
					changeType = 0;
					playerFieldMoveScript.moveStop = 0;
					this.gameObject.SetActive (false);
					break;

				case "Town1Out":
					changeType = 0;
					playerFieldMoveScript.moveStop = 0;
					this.gameObject.SetActive (false);
					break;

				case "GameOver":
					changeType = 0;
					this.gameObject.SetActive (false);
					break;
				case "Clear":
					changeType = 0;
					this.gameObject.SetActive (false);
					break;
				case "Title":
					changeType = 0;
					this.gameObject.SetActive (false);
					break;
				}
				/*changeType = 0;
				turnManager.BattleStart ();*/
				this.gameObject.SetActive (false);
			}
			break;

		/*case 3:
			fadeSpeed = 0.05f;
			GetComponent<Image> ().color = new Color (red, green, blue, alfa);
			alfa += fadeSpeed;
			if (alfa >= 1) {
				changeType = 0;
				turnManager.FieldBack ();
			}
			break;

		case 4:
			fadeSpeed = 0.1f;
			GetComponent<Image> ().color = new Color (red, green, blue, alfa);
			alfa -= fadeSpeed;
			if (alfa <= 0) {
				changeType = 0;
				this.gameObject.SetActive (false);
			}
			break;
		case 5:
			fadeSpeed = 0.05f;
			GetComponent<Image> ().color = new Color (red, green, blue, alfa);
			alfa += fadeSpeed;
			if (alfa >= 1) {
				changeType = 0;

				this.gameObject.SetActive (false);
			}
			break;*/
		}

	}

	void BattleStart(){
		SceneManager.LoadScene ("Battle");
	}
	


}
