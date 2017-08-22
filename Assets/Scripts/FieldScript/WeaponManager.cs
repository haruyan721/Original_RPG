using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeaponManager : MonoBehaviour {

	public static int weaponNum;
	public string weaponName; 
	public int addPower;
	public float attackRange;
	GameObject swordEquCheck;
	GameObject bowEquCheck;
	// Use this for initialization
	void Awake(){
		bowEquCheck = GameObject.Find ("BowEquCheck");
		swordEquCheck = GameObject.Find ("SwordEquCheck");
		if (PlayerPrefs.GetInt ("saveCheck") == 1 && PlayerFieldMoveScript.sceneStart == 0) {
			weaponNum = PlayerPrefs.GetInt ("equWeaponSaveDate");
		} else if (PlayerPrefs.GetInt ("saveCheck") == 0 && PlayerFieldMoveScript.sceneStart == 0) {
			weaponNum = 1;
		}
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		switch (weaponNum){
		case 1:
			weaponName = "レクトソード";
			addPower = 6;
			attackRange = 3;
			if (SceneManager.GetActiveScene ().name == "Field") {
				swordEquCheck.SetActive (true);
				bowEquCheck.SetActive (false);
			}
			break;
		case 2:
			weaponName = "コアンボウ";
			addPower = 3;
			attackRange = 13;
			if (SceneManager.GetActiveScene ().name == "Field") {
				swordEquCheck.SetActive (false);
				bowEquCheck.SetActive (true);
			}
			break;
		}
	}
}
