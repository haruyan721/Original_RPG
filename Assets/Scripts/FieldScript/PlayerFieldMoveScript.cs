using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerFieldMoveScript : MonoBehaviour {

	public static Vector3 mypos = new Vector3(0,0.725f,0);
	public static int battleEnemy = 0;
	public int townMode;
	int moveSpeed = 15;
	public static int sceneStart = 0;
	public int moveStop = 0;
	GameObject fadePanel;
	GameObject mobileJoystick;
	FadeManager fadeManager;
	PadClickCheck padClickCheck;


	// Use this for initialization

	void Awake(){
		if (PlayerPrefs.GetInt ("saveCheck") == 1 && sceneStart == 0) {
			mypos = new Vector3(PlayerPrefs.GetFloat("player_XPosSaveDate"),0.725f,PlayerPrefs.GetFloat("player_ZPosSaveDate"));
			townMode = PlayerPrefs.GetInt ("townModeSaveDate");
		}
		transform.position = mypos;
		fadePanel = GameObject.Find ("FadePanel");
		//mobileJoystick = GameObject.Find ("MobileJoystick");
		fadeManager = fadePanel.GetComponent<FadeManager> ();
		padClickCheck = GetComponent<PadClickCheck> ();
	}


	void Start () {
		if (sceneStart == 1) {
			moveStop = 1;
			fadeManager.fadeName = "BattleEnd";
			fadePanel.SetActive (true);
			fadeManager.changeType = 2;
		}
		sceneStart = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (moveStop == 1) {
			//mobileJoystick.SetActive (false);		
		}else if(moveStop == 0){
			//mobileJoystick.SetActive (true);	
		}



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
		/*if (padClickCheck.padClick == 1 && moveStop == 0) {
			transform.position += new Vector3 (CrossPlatformInputManager.GetAxisRaw ("Horizontal") * 15, 0, CrossPlatformInputManager.GetAxisRaw ("Vertical") * 15) * Time.deltaTime;
		}*/
	}

	/*void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Enemy") {
			moveStop = 1;
			fadePanel.SetActive (true);
			fadeManager.changeType = 1;
		}
		if (col.gameObject.tag == "Town1In") {
			moveStop = 1;
			fadeManager.fadeSpeed = 0.05f;
			fadeManager.movePos = new Vector3 (-35, 0.725f, 0);
			fadeManager.fadeName = "Town1In";
			fadePanel.SetActive (true);
			fadeManager.changeType = 1;
			townMode = 1;
		}
		if (col.gameObject.tag == "TownOnt") {
			moveStop = 1;
			fadeManager.fadeSpeed = 0.05f;
			fadeManager.movePos = new Vector3 (-25, 0.725f, 0);
			fadeManager.fadeName = "Town1Out";
			fadePanel.SetActive (true);
			fadeManager.changeType = 2;
			townMode = 0;
		}
	}*/
		 
}
