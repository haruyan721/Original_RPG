using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFlashingScript : MonoBehaviour {
	GameObject player;
	PlayerAttacker playerAttacker;
	WeaponManager weaponManager;
	float changeSpeed = 0.02f;
	float red = 1;
	int changeCheck;
	string checkName;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		playerAttacker = player.GetComponent<PlayerAttacker> ();
		weaponManager = player.GetComponent<WeaponManager> ();
		checkName = transform.name;
		//red = GetComponent<Image> ().color.r;
	}

	// Update is called once per frame
	void Update () {
		if (red < 0.3 || red > 1) {
			changeSpeed  = changeSpeed * -1;
		}
			
		switch (checkName) {
		case "Atack":
			if (playerAttacker.dis <= weaponManager.attackRange) {
				GetComponent<Image> ().color = new Color (red += changeSpeed, 255, 255, 1);
			}
			else {
				red = 1f;
				GetComponent<Image> ().color = new Color (red += changeSpeed, 255, 255, 1);
			}
			break;
		case "Skill1":
			if (playerAttacker.dis <= 6f) {
				GetComponent<Image> ().color = new Color (red += changeSpeed, 255, 255, 1);
			}
			else {
				
				red = 1f;
				GetComponent<Image> ().color = new Color (red += changeSpeed, 255, 255, 1);
			}
			break;
		case "Skill2":
			if (playerAttacker.dis <= 4f) {
				GetComponent<Image> ().color = new Color (red += changeSpeed, 255, 255, 1);
			}
			else {
				red = 1f;
				GetComponent<Image> ().color = new Color (red += changeSpeed, 255, 255, 1);
			}
			break;
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

	}
}
