using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FieldBattleSetUpScript : MonoBehaviour {

	GameObject date;
	FieldParameters fieldParameters;

	// Use this for initialization
	void Start () {
		date = GameObject.Find ("Dates");
		fieldParameters = date.GetComponent<FieldParameters> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {
			SceneManager.LoadScene ("Battle");
			fieldParameters.playerPos = col.transform.position;
		}
	}
}
