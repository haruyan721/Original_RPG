using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEquScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SwordEqu(){
		WeaponManager.weaponNum = 1;
	}

	public void BowEqu(){
		WeaponManager.weaponNum = 2;
	}
}
