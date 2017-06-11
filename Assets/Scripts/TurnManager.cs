using UnityEngine;
using System.Collections;

public class TurnManager : MonoBehaviour {
	
	public int turncount = 1; //ターン番号
	public int playerTurnNum; //プレイヤーのターン順
	public int enemyTurnNum; //敵のターン順
	public int menber = 2;
	int playerSpeedCheck = 0; //プレイヤーのスピードを取得
	int enemySpeedCheck = 0; //敵のスピードを取得
	GameObject player;
	GameObject enemy;

	void Awake (){
		
		player = GameObject.Find ("Player"); //プレイヤーを取得
		PlayerStatus playerStatus = player.GetComponent<PlayerStatus> (); //ステータスから素早さを取得
		playerSpeedCheck = playerStatus.playerSpeed; //素早さを代入
		enemy = GameObject.Find("Enemy"); //敵を取得
		EnemyStatus enemyStatus = enemy.GetComponent<EnemyStatus> (); //ステータスから素早さを以下略
		enemySpeedCheck = enemyStatus.enemySpeed; //代入

		if (playerSpeedCheck >= enemySpeedCheck) { //どちらが先に動くかの処理
			
			playerTurnNum = 1;
			enemyTurnNum = 2;

		} else {
			
			playerTurnNum = 2;
			enemyTurnNum = 1;

		}

	}

	void Start () {


	}


	void Update () {
	
	}

	public void Next(){
		
		if (turncount == menber) {
			
			turncount = 1;

		} else {
			
			turncount++;

		}

	}
}
