using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEquScript : MonoBehaviour {
	AudioSource audio;
	public AudioClip equSound;
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SwordEqu(){
		if (WeaponManager.weaponNum == 2) {
			audio.PlayOneShot (equSound);
			WeaponManager.weaponNum = 1;
		}
	}

	public void BowEqu(){
		if (WeaponManager.weaponNum == 1) {
			audio.PlayOneShot (equSound);
			WeaponManager.weaponNum = 2;
		}
	}
}
