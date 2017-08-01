using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPbarManagement : MonoBehaviour {

	GameObject playerHpBar;
	private Slider _playerHpDraw;


	// Use this for initialization
	void Start () {
		playerHpBar = GameObject.Find ("HP");
		_playerHpDraw = playerHpBar.GetComponent<Slider> ();
	}
	
	// Update is called once per frame
	void Update () {
		_playerHpDraw.value = PlayerStatus.playerHp;
	}
		
}
