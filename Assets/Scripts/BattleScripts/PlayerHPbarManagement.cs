using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPbarManagement : MonoBehaviour {

	GameObject playerHpBar;
	private Slider _playerHpDraw;
	float hpProportion = 0;


	// Use this for initialization
	void Start () {
		playerHpBar = GameObject.Find ("HP");
		_playerHpDraw = playerHpBar.GetComponent<Slider> ();
	}
	
	// Update is called once per frame
	void Update () {
		hpProportion = (float)PlayerStatus.playerHp / (float)PlayerStatus.maxPlayerHp;
		_playerHpDraw.value = hpProportion;
	}
		
}
