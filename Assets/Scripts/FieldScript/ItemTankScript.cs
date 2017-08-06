using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTankScript : MonoBehaviour {
	public static int potionNum = 3;
	// Use this for initialization
	void Awake(){
		if (PlayerPrefs.GetInt("saveCheck") == 1 && PlayerFieldMoveScript.sceneStart == 0) {
			potionNum = PlayerPrefs.GetInt ("potionNullSaveDate");
		}
	}
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
