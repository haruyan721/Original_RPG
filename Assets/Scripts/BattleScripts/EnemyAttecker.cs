﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttecker : MonoBehaviour {
	
	private Rigidbody _rigidbody;
	PlayerStatus playerStatus;
	EnemyStatus enemyStatus;
	GameObject player;
	GameObject turnManagement;
	AudioSource audio;
	public TurnManager turnManager;
	public PlayerMover playermover;
	public EnemyMover enemyMover;
	public GameObject hitEffect;
	public AudioClip enemyAttackSound;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
		turnManagement = GameObject.Find("TurnManagement");
		player = GameObject.Find ("Player");
		turnManager = turnManagement.GetComponent<TurnManager> ();
		playermover = player.GetComponent<PlayerMover> ();
		playerStatus = player.GetComponent<PlayerStatus> ();
		enemyMover = GetComponent<EnemyMover> ();
		enemyStatus = GetComponent<EnemyStatus> ();
		_rigidbody = GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (turnManager.enemyTurnNum == turnManager.turncount && _rigidbody.velocity == new Vector3 (0, 0, 0) && enemyMover.enemyComandcheck == 0 && enemyMover.enemyMovecheck == 1) {
			_rigidbody.constraints = RigidbodyConstraints.FreezeAll;
			float dis = Vector3.Distance (playermover.movingPos, enemyMover.enemyPos);
			if(dis <= 3f && enemyMover.enemyComandcheck == 0){
				int damage = enemyStatus.enemyPower + Random.Range (-2, 2);
				audio.PlayOneShot (enemyAttackSound);
				Instantiate (hitEffect, player.transform.position, player.transform.rotation);
				playerStatus.HPDamage (damage);
			}
			enemyMover.enemyComandcheck++;
		}
}
}
