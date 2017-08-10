using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearScript : MonoBehaviour {
	GameObject fadePanel;
	FadeManager fadeManager;
	// Use this for initialization
	void Start () {
		fadePanel = GameObject.Find ("FadePanel");
		fadeManager = fadePanel.GetComponent<FadeManager> ();
		fadeManager.fadeName = "Clear";
		fadeManager.changeType = 2;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
