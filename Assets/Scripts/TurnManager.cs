using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour {
	
	public int turncount = 1; //ターン番号
	public int playerTurnNum; //プレイヤーのターン順
	public int enemyTurnNum; //敵のターン順
	GameObject [] enemys;
	GameObject [] players;
	public int playerMenber;
	public int enemyMenber;
	public int allMenber = 2;
	int playerSpeedCheck = 0; //プレイヤーのスピードを取得
	int enemySpeedCheck = 0; //敵のスピードを取得
	GameObject player;
	GameObject enemy;
	public Text turnWindow;
	string turnText;

	void Awake (){
		
		player = GameObject.Find ("Player"); //プレイヤーを取得
		PlayerStatus playerStatus = player.GetComponent<PlayerStatus> (); //プレイヤーのステータスから素早さを取得
		playerSpeedCheck = playerStatus.playerSpeed; //素早さを代入
		enemy = GameObject.Find("Enemy"); //敵を取得
		EnemyStatus enemyStatus = enemy.GetComponent<EnemyStatus> (); //敵のステータスから素早さを取得
		enemySpeedCheck = enemyStatus.enemySpeed; //代入


		if (playerSpeedCheck >= enemySpeedCheck) { //どちらが先に動くかの処理
			
			playerTurnNum = 1; //ターン順の決定
			enemyTurnNum = 2;
			turnText = "your turn"; 
			turnWindow.text = turnText;

		} else {
			
			playerTurnNum = 2; //ターン順の決定
			enemyTurnNum = 1;
			turnText = "enemy turn"; 
			turnWindow.text = turnText;

		}

	}

	void Start () {


	}


	void Update () {
		
	}

	public void Next(){
		
		if (turncount == allMenber) {

			turncount = 1;

		} else {
			
			turncount++;

		}

		if (turncount == playerTurnNum) {
			turnText = "your turn"; 
		} else {
			turnText = "enemy turn"; 
		}
		turnWindow.text = turnText;

	}



	void MenberCheck(){
		players = GameObject.FindGameObjectsWithTag("player");
		playerMenber = players.Length;
		enemys = GameObject.FindGameObjectsWithTag ("Enemy");
		enemyMenber = enemys.Length;
		allMenber = playerMenber + enemyMenber;
	}
}
