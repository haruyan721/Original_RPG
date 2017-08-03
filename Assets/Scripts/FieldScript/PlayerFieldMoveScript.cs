using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFieldMoveScript : MonoBehaviour {

	public static Vector3 mypos = new Vector3(0,0.725f,0);
	public static GameObject battleEnemy = null;
	int moveSpeed = 15;
	public static int sceneStart = 0;
	int moveStop = 0;
	GameObject fadePanel;
	SceneChangeManager sceneChangeManager;


	// Use this for initialization

	void Awake(){
		if (PlayerPrefs.GetInt ("saveCheck") == 1 && sceneStart == 0) {
			mypos = new Vector3(PlayerPrefs.GetFloat("player_XPosSaveDate"),0.725f,PlayerPrefs.GetFloat("player_ZPosSaveDate"));
		}
		transform.position = mypos;
		fadePanel = GameObject.Find ("FadePanel");
		sceneChangeManager = fadePanel.GetComponent<SceneChangeManager> ();
	}


	void Start () {
		if (sceneStart == 1) {
			fadePanel.SetActive (true);
			sceneChangeManager.changeType = 4;
		}
		sceneStart = 1;
	}
	
	// Update is called once per frame
	void Update () {
		



	}
	void FixedUpdate(){
		if (moveStop == 0) {
			if (Input.GetKey (KeyCode.W)) {
				transform.position += new Vector3 (0, 0, moveSpeed) * Time.deltaTime;
			}

			if (Input.GetKey (KeyCode.S)) {
				transform.position -= new Vector3 (0, 0, moveSpeed) * Time.deltaTime;
			}

			if (Input.GetKey (KeyCode.A)) {
				transform.position -= new Vector3 (moveSpeed, 0, 0) * Time.deltaTime;
			}

			if (Input.GetKey (KeyCode.D)) {
				transform.position += new Vector3 (moveSpeed, 0, 0) * Time.deltaTime;
			}
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Enemy") {
			moveStop = 1;
			fadePanel.SetActive (true);
			sceneChangeManager.changeType = 1;
		}
	}
}
