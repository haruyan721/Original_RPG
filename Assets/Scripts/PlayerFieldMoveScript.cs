﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFieldMoveScript : MonoBehaviour {

	int moveSpeed = 15;
	PlayerModeScript playerModeScript;


	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey (KeyCode.W)) {
			transform.position += new Vector3(0,0,moveSpeed) * Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.S)) {
			transform.position -= new Vector3(0,0,moveSpeed) * Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.A)) {
			transform.position -= new Vector3(moveSpeed,0,0) * Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.D)) {
			transform.position += new Vector3(moveSpeed,0,0) * Time.deltaTime;
		}

	}
}
