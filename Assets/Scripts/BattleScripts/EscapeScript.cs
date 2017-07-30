using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeScript : MonoBehaviour {
	GameObject turnManagement;
	TurnManager turnManager;
	// Use this for initialization
	void Start () {
		turnManagement = GameObject.Find ("TurnManagement");
		turnManager = turnManagement.GetComponent<TurnManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Escape(){

	}
}
