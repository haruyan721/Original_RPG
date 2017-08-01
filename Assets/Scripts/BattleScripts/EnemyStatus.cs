﻿using UnityEngine;
using System.Collections;

public class EnemyStatus : MonoBehaviour {
	
	public int enemySpeed = 8; //素早さ
	public int enemyPower = 4; //攻撃力
	public int enemyHp = 12; //体力
	GameObject turnManagement;
	TurnManager turnManager;

	void Start () {
		turnManagement = GameObject.Find ("TurnManagement");
		turnManager = turnManagement.GetComponent<TurnManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyHp <= 0) {
			turnManager.enemyMenber--;
			turnManager.allMenber--;
			Destroy (this.gameObject);
		}
	}

	public void EnemyDamage(int damage){
		enemyHp -= damage;
	}
}
