using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour {
	GameObject fadePanel;
	FadeScript fadeScript;
	public float fadeSpeed = 0.01f;
	float alfa = 0;
	float red,green,blue;
	public int changeType = 0;
	// Use this for initialization
	void Start () {
		red = GetComponent<Image> ().color.r;
		green = GetComponent<Image> ().color.g;
		blue = GetComponent<Image> ().color.b;

	}
	
	// Update is called once per frame
	void Update () {
		switch (changeType) {

		case 1:
			GetComponent<Image> ().color = new Color (red, green, blue, alfa);
			alfa += fadeSpeed;
			Debug.Log (alfa);
			if (alfa >= 1) {
				changeType = 0;
				BattleStart ();
			}
			break;

		case 2:
			GetComponent<Image> ().color = new Color (red, green, blue, alfa);
			alfa -= fadeSpeed;
			if (alfa <= 0) {
				changeType = 0;
			}
			break;

		}
	}


	void BattleStart(){
		SceneManager.LoadScene ("Battle");
	}


}
