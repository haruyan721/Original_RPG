using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour {

	GameObject turnManagement;
	GameObject fadePanel;
	TurnManager turnManager;
	public float fadeSpeed = 0.01f;
	float alfa = 0;
	float red,green,blue;
	public int changeType = 0;
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

		if (SceneManager.GetActiveScene ().name == "Field" && PlayerFieldMoveScript.sceneStart == 0) {
			this.gameObject.SetActive (false);
		} else if (SceneManager.GetActiveScene ().name == "Field" && PlayerFieldMoveScript.sceneStart == 1) {
			alfa = 1;
			GetComponent<Image> ().color = new Color (red, green, blue, alfa);
		}
	}
	
	// Update is called once per frame
	void Update () {
		switch (changeType) {

		case 1:
			fadeSpeed = 0.05f;
			GetComponent<Image> ().color = new Color (red, green, blue, alfa);
			alfa += fadeSpeed;
			if (alfa >= 1) {
				changeType = 0;
				BattleStart ();
			}
			break;

		case 2:
			fadeSpeed = 0.1f;
			GetComponent<Image> ().color = new Color (red, green, blue, alfa);
			alfa -= fadeSpeed;
			if (alfa <= 0) {
				changeType = 0;
				turnManager.BattleStart ();
				this.gameObject.SetActive(false);
			}
			break;

		case 3:
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
				this.gameObject.SetActive(false);
			}
			break;

		}
	}


	void BattleStart(){
		SceneManager.LoadScene ("Battle");
	}


}
