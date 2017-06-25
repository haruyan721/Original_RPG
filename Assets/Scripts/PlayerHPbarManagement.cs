using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPbarManagement : MonoBehaviour {

	PlayerStatus playerStatus;
	GameObject playerHpBar;
	private Slider _playerHpDraw;

	// Use this for initialization
	void Start () {
		playerHpBar = GameObject.Find ("HP");
		_playerHpDraw = playerHpBar.GetComponent<Slider> ();
		playerStatus = GetComponent<PlayerStatus> ();
	}
	
	// Update is called once per frame
	void Update () {
		_playerHpDraw.value = playerStatus.playerHp;
	}
		
}
