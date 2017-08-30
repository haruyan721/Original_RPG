using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTankScript : MonoBehaviour {
	public static int potionNum = 1;
	public static int tabletNum = 1;
	// Use this for initialization
	void Awake(){
		if (PlayerPrefs.GetInt ("saveCheck") == 0 && PlayerFieldMoveScript.sceneStart == 0) {
			potionNum = 1;
			tabletNum = 1;
		}
		if (PlayerPrefs.GetInt("saveCheck") == 1 && PlayerFieldMoveScript.sceneStart == 0) {
			potionNum = PlayerPrefs.GetInt ("potionNumSaveDate");
			tabletNum = PlayerPrefs.GetInt ("tabletNumSaveDate");
		}
	}
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
