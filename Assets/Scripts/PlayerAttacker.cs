using UnityEngine;
using System.Collections;

public class PlayerAttacker : MonoBehaviour {
	
	public GameObject hitEffect; //攻撃時のエフェクト;
	GameObject player;
	GameObject enemy;
	PlayerMover playermover;
	PlayerStatus playerstatus;
	EnemyMover enemymover;
	EnemyStatus enemyStatus;
	GameObject turnManagement; //ターンを管理するオブジェクト
	public TurnManager turnManager; //TurnManagerを入れる用

	void Start () {
		
		player = GameObject.Find ("Player");
		playermover = player.GetComponent<PlayerMover> (); //プレイヤーの場所を記したスクリプトを取得
		playerstatus = player.GetComponent<PlayerStatus> (); //プレイヤーのステータスを取得
		enemy = GameObject.Find ("Enemy");
		enemymover = enemy.GetComponent<EnemyMover> (); //敵の場所を記したスクリプトを取得
		enemyStatus = enemy.GetComponent<EnemyStatus> (); //敵のステータスを取得
		turnManagement = GameObject.Find ("TurnManagement"); //ターン用のオブジェクトを取得
		turnManager = turnManagement.GetComponent<TurnManager> (); //turnManagerにTurnManagerを代入

	}

	void Update () {
	
	}

	public void Attack(){
		
		if (turnManager.playerTurnNum == turnManager.turncount) {
			
			float dis = Vector3.Distance (playermover.movingPos, enemymover.myPos); //プレイヤーと敵の距離を取得
			if (dis <= 3f) {
				
				int playerAttack = playerstatus.playerPower;
				int damage = playerAttack + Random.Range (0, 4); //ダメージ算出 
				enemyStatus.enemyHp -= damage; //ダメージ
				Debug.Log (enemyStatus.enemyHp);

			}

		}
	
	}
}
