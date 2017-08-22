using UnityEngine;
using System.Collections;

public class PlayerAttacker : MonoBehaviour {
	
	public GameObject hitEffect; //攻撃時のエフェクト;
	GameObject player;
	GameObject enemy;
	PlayerMover playermover;
	EnemyMover enemymover;
	EnemyStatus enemyStatus;
	SkillWindowPopup skillWindowPopUp;
	WeaponManager weaponManager;
	GameObject turnManagement; //ターンを管理するオブジェクト
	AudioSource audio;
	TurnManager turnManager; //TurnManagerを入れる用
	public AudioClip attackSound1;
	public float dis;

	void Start () {
		player = GameObject.Find ("Player");
		playermover = player.GetComponent<PlayerMover> (); //プレイヤーの場所を記したスクリプトを取得
		switch (PlayerFieldMoveScript.battleEnemy) {
		case 1:
			enemy = GameObject.Find ("Battle_Enemy1(Clone)");
			break;
		case 2:
			enemy = GameObject.Find("Battle_Enemy2(Clone)"); //敵を取得
			break;
		case 3:
			enemy = GameObject.Find("Battle_Boss(Clone)"); //敵を取得
			break;
		}
		audio = player.GetComponent<AudioSource> ();
		weaponManager = player.GetComponent<WeaponManager> ();
		enemymover = enemy.GetComponent<EnemyMover> (); //敵の場所を記したスクリプトを取得
		enemyStatus = enemy.GetComponent<EnemyStatus> (); //敵のステータスを取得
		skillWindowPopUp = player.GetComponent<SkillWindowPopup>();
		turnManagement = GameObject.Find ("TurnManagement"); //ターン用のオブジェクトを取得
		turnManager = turnManagement.GetComponent<TurnManager> (); //turnManagerにTurnManagerを代入

	}

	void Update () {
		dis = Vector3.Distance (playermover.movingPos, enemymover.enemyPos); //プレイヤーと敵の距離を取得

	}

	public void Attack(){
		
		if (turnManager.playerTurnNum == turnManager.turncount && playermover.playercomandcheck == 0) {
			

			if (dis <= weaponManager.attackRange) {
				int damage = PlayerStatus.playerPower + weaponManager.addPower + Random.Range (-3, 2) ;
				enemyStatus.EnemyDamage (damage);
				audio.PlayOneShot (attackSound1);
				Instantiate (hitEffect, enemy.transform.position, enemy.transform.rotation);
				if (skillWindowPopUp.popUpcheck == 1) {
					skillWindowPopUp.PopUpDown();
				}
				playermover.playercomandcheck = 1;
			}

		}
	
	}
}
