using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFieldMoveScript : MonoBehaviour {

	public static Vector3 mypos = new Vector3(0,0.725f,0);
	public static GameObject battleEnemy = null;
	int moveSpeed = 15;


	// Use this for initialization

	void Awake(){
		
		transform.position = mypos;

	}


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

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Enemy") {
			mypos = this.transform.position;
			battleEnemy = col.gameObject;

			SceneManager.LoadScene ("Battle");
		}
	}
}
