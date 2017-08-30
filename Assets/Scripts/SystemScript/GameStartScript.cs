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
	AudioSource audio;
	Text operationPopButtonSentence;
	int checkPopUp;
	int operetionPop;
	FadeManager fadeManager;
	StartOperationWindowScript startOperationWindowScript;
	WindowPopDownSoundScript popSound;
	public AudioClip gameStartSound;
	public int ScreenWidth;
	public int ScreenHeight;

	// Use this for initialization
	void Awake(){
		if (Application.platform == RuntimePlatform.WindowsPlayer ||
			Application.platform == RuntimePlatform.OSXPlayer ||
			Application.platform == RuntimePlatform.LinuxPlayer  && PlayerFieldMoveScript.sceneStart == 0)
		{
			Screen.SetResolution(ScreenWidth, ScreenHeight, false);
		}
	}
	void Start () {
		startCheckFade = GameObject.Find ("StartCheckFade");
		operationPanel = GameObject.Find ("OperationWindow");
		operationPopButtonText = GameObject.Find ("OperationPopText");
		fadePanel = GameObject.Find ("FadePanel");
		reStartButton = GameObject.Find ("ReStartButton");
		audio = GetComponent<AudioSource> ();
		operationPopButtonSentence = operationPopButtonText.GetComponent<Text> ();
		fadeManager = fadePanel.GetComponent<FadeManager> ();
		startOperationWindowScript = GetComponent<StartOperationWindowScript> ();
		popSound = GetComponent<WindowPopDownSoundScript> ();
		startCheckFade.SetActive (false);
		operationPanel.SetActive (false);
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
		audio.PlayOneShot (gameStartSound);
		PlayerPrefs.DeleteAll();
		fadePanel.SetActive (true);
		FadeManager.fadeSpeed = 0.05f;
		fadeManager.fadeName = "GoField";
		fadeManager.changeType = 1;
		//SceneManager.LoadScene ("Field");
	}
	public void GameReStart(){
		audio.PlayOneShot (gameStartSound);
		fadePanel.SetActive (true);
		FadeManager.fadeSpeed = 0.05f;
		fadeManager.fadeName = "GoField";
		fadeManager.changeType = 1;
		//SceneManager.LoadScene ("Field");
	}
	public void StartCheckPopUp(){
		if (PlayerPrefs.GetInt ("saveCheck") == 1) {
			if (checkPopUp == 0) {
				popSound.PopUpSound ();
				startCheckFade.SetActive (true);
				checkPopUp = 1;
			} else if (checkPopUp == 1) {
				popSound.PopDownSound ();
				startCheckFade.SetActive (false);
				checkPopUp = 0;
			}
		} else if (PlayerPrefs.GetInt ("saveCheck") == 0) {
			GameStart ();
		}
	}
	public void OperetionPop(){
		if (checkPopUp == 0) {
			startOperationWindowScript.OperaNum = 1;
			popSound.PopUpSound ();
			operationPopButtonSentence.text = "閉じる";
			checkPopUp = 1;
			operationPanel.SetActive (true);
		} else if (checkPopUp == 1) {
			popSound.PopDownSound ();
			operationPopButtonSentence.text = "操作説明";
			checkPopUp = 0;
			operationPanel.SetActive (false);
		}
	}
}
