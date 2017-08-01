using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMPbarManagement : MonoBehaviour {

	GameObject playerMpBar;
	private Slider _mpDraw;

	// Use this for initialization
	void Start () {
		playerMpBar = GameObject.Find ("MP");
		_mpDraw = playerMpBar.GetComponent<Slider> ();
	}
	
	// Update is called once per frame
	void Update () {
		_mpDraw.value = PlayerStatus.playerMp;
	}
}
