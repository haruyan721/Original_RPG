using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPopUpScript : MonoBehaviour {
	int popcheck = 0;
	GameObject menuWindows;
	// Use this for initialization
	void Start () {
		menuWindows = GameObject.Find ("MenuWindows");
		menuWindows.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void MenuPop(){
		if (popcheck == 0) {
			menuWindows.SetActive (true);
			popcheck = 1;
		} else if (popcheck == 1) {
			menuWindows.SetActive (false);
			popcheck = 0;
		}
	}
}
