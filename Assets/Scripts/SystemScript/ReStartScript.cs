using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStartScript : MonoBehaviour {
	GameObject fadePanel;
	FadeManager fadeManager;
	// Use this for initialization
	void Start () {
		fadePanel = GameObject.Find ("FadePanel");
		fadeManager = fadePanel.GetComponent<FadeManager> ();
		fadeManager.fadeName = "GameOver";
		fadeManager.changeType = 2;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void GoTitleFade(){
		PlayerFieldMoveScript.sceneStart = 0;
		fadePanel.SetActive (true);
		fadeManager.fadeName = "Title";
		FadeManager.fadeSpeed = 0.05f;
		fadeManager.changeType = 1;
	}

}
