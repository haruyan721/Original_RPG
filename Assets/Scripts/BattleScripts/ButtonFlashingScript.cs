using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFlashingScript : MonoBehaviour {
	GameObject player;
	PlayerAttacker playerAttacker;
	float changeSpeed = 0.02f;
	float red = 1;
	int changeCheck;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		playerAttacker = player.GetComponent<PlayerAttacker> ();
		//red = GetComponent<Image> ().color.r;
	}

	// Update is called once per frame
	void Update () {
		if (red < 0.3 || red > 1) {
			changeSpeed  = changeSpeed * -1;
		}

		Debug.Log (red);

		if(playerAttacker.dis <= 3f){
			GetComponent<Image> ().color = new Color (red += changeSpeed, 255, 255, 1);
		}

		/*if (playerAttacker.dis <= 3f) {
			if (changeCheck == 0) {
				GetComponent<Image> ().color = new Color (red, green, blue, alfa);
				red -= changeSpeed;
			}else if(changeCheck == 1){
				GetComponent<Image> ().color = new Color (red, green, blue, alfa);
				red += changeSpeed;
			}

			while (red >= 155) {
				Debug.Log ("plus");
				GetComponent<Image> ().color = new Color (red, green, blue, alfa);
				red -= changeSpeed * Time.deltaTime;
			}
			while (red <= 255) {
				GetComponent<Image> ().color = new Color (red, green, blue, alfa);
				red += changeSpeed * Time.deltaTime;
			}
			if (red >= 155f) {
				Debug.Log ("plus");
				GetComponent<Image> ().color = new Color (red, green, blue, alfa);
				red -= changeSpeed * Time.deltaTime;
			} else if (red <= 155f) {

				GetComponent<Image> ().color = new Color (red, green, blue, alfa);
				red += changeSpeed * Time.deltaTime;
			}*/

		else {
			Debug.Log ("stay");
			red = 1f;
		}
	}
}
