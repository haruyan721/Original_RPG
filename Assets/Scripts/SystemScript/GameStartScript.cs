using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStartScript : MonoBehaviour {
	GameObject startCheckFade;
	GameObject operationPanel;
	GameObject operationPopButtonText;
	GameObject fadePanel;
	GameObject reStartButton;
	Text operationPopButtonSentence;
	int checkPopUp;
	int operetionPop;
	FadeManager fadeManager;

	// Use this for initialization
	void Start () {
		startCheckFade = GameObject.Find ("StartCheckFade");
		operationPanel = GameObject.Find ("OperationWindow");
		operationPopButtonText = GameObject.Find ("OperationPopText");
		fadePanel = GameObject.Find ("FadePanel");
		reStartButton = GameObject.Find ("ReStartButton");
		//operationPopButtonSentence = operationPopButtonText.GetComponent<Text> ();
		fadeManager = fadePanel.GetComponent<FadeManager> ();
		startCheckFade.SetActive (false);
		//operationPanel.SetActive (false);
		FadeManager.fadeSpeed = 0.1f;
		fadeManager.fadeName = "Title";
		fadeManager.changeType = 2;
		if (PlayerPrefs.GetInt ("saveCheck") == 0) {
			reStartButton.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GameStart(){
		PlayerPrefs.DeleteAll();
		fadePanel.SetActive (true);
		FadeManager.fadeSpeed = 0.05f;
		fadeManager.fadeName = "GoField";
		fadeManager.changeType = 1;
		//SceneManager.LoadScene ("Field");
	}
	public void GameReStart(){
		fadePanel.SetActive (true);
		FadeManager.fadeSpeed = 0.05f;
		fadeManager.fadeName = "GoField";
		fadeManager.changeType = 1;
		//SceneManager.LoadScene ("Field");
	}
	public void StartCheckPopUp(){
		if (PlayerPrefs.GetInt ("saveCheck") == 1) {
			if (checkPopUp == 0) {
				startCheckFade.SetActive (true);
				checkPopUp = 1;
			} else if (checkPopUp == 1) {
				startCheckFade.SetActive (false);
				checkPopUp = 0;
			}
		} else if (PlayerPrefs.GetInt ("saveCheck") == 0) {
			GameStart ();
		}
	}
	public void OperetionPop(){
		if (checkPopUp == 0) {
			operationPopButtonSentence.text = "閉じる";
			checkPopUp = 1;
			operationPanel.SetActive (true);
		} else if (checkPopUp == 1) {
			operationPopButtonSentence.text = "操作説明";
			checkPopUp = 0;
			operationPanel.SetActive (false);
		}
	}
}
