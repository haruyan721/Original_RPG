﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TurnManager : MonoBehaviour {

	GameObject [] enemys;
	GameObject [] players;
	public int turncount = 1; //ターン番号
	public int playerTurnNum; //プレイヤーのターン順
	public int enemyTurnNum; //敵のターン順
	public int playerMenber;
	public int enemyMenber;
	public int allMenber = 2;
	int playerSpeedCheck = 0; //プレイヤーのスピードを取得
	int enemySpeedCheck = 0; //敵のスピードを取得
	int battleEndCheck = 0;
	public Text textWindow;
	string battleText;
	GameObject player;
	GameObject enemy;
	PlayerStatus playerStatus;
	EnemyStatus enemyStatus;


	void Awake (){
		
		player = GameObject.Find ("Player"); //プレイヤーを取得
		playerStatus = player.GetComponent<PlayerStatus> (); //プレイヤーのステータスから素早さを取得
		playerSpeedCheck = playerStatus.playerSpeed; //素早さを代入
		enemy = GameObject.Find("Enemy"); //敵を取得
		enemyStatus = enemy.GetComponent<EnemyStatus> (); //敵のステータスから素早さを取得
		enemySpeedCheck = enemyStatus.enemySpeed; //代入
		playerStatus.StatusStorageExport ();
		//transActionScript = dates.GetComponent<TransActionScript> ();
		MenberCheck();


		if (playerSpeedCheck >= enemySpeedCheck) { //どちらが先に動くかの処理
			
			playerTurnNum = 1; //ターン順の決定
			enemyTurnNum = 2;
			battleText = "your turn"; 
			textWindow.text = battleText;

		} else {
			
			playerTurnNum = 2; //ターン順の決定
			enemyTurnNum = 1;
			battleText = "enemy turn"; 
			textWindow.text = battleText;

		}

	}

	void Start () {


	}


	void Update () {
		if (enemyMenber == 0) {
			battleText = "You Win!!";
			battleEndCheck = 1;
			playerStatus.BattleBonusGet ();
			textWindow.text = battleText;
			Invoke ("FieldBack", 2);
		}

	}

	public void Next(){
		
		if (turncount == allMenber && battleEndCheck == 0) {
			turncount = 1;
		} else {
			turncount++;
		}

		if (turncount == playerTurnNum && battleEndCheck == 0) {
			battleText = "your turn"; 
		} else {
			battleText = "enemy turn"; 
		}
		textWindow.text = battleText;

	}
		
	void MenberCheck(){
		players = GameObject.FindGameObjectsWithTag("Player");
		playerMenber = players.Length;
		enemys = GameObject.FindGameObjectsWithTag ("Enemy");
		enemyMenber = enemys.Length;
		allMenber = playerMenber + enemyMenber;
	}

	void FieldBack(){
		playerStatus.StatusStorageInport ();
		SceneManager.LoadScene ("Field");
	}
		
}
