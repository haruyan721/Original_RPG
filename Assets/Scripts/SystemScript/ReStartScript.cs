﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStartScript : MonoBehaviour {
	GameObject fadePanel;
	FadeManager fadeManager;
	public int reStartCheck = 1;
	// Use this for initialization
	void Start () {
		fadePanel = GameObject.Find ("FadePanel");
		fadeManager = fadePanel.GetComponent<FadeManager> ();
		fadeManager.fadeName = "GameOver";
		fadeManager.changeType = 2;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.P) && reStartCheck == 0) {
			PlayerFieldMoveScript.sceneStart = 0;
			SceneManager.LoadScene ("Field");
		}
		
	}
}
