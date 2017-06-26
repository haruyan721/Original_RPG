using UnityEngine;
using System.Collections;

public class SkillManager : MonoBehaviour {

	GameObject enemy;
	PlayerStatus playerStatus;
	PlayerMover playermover;
	EnemyMover enemyMover;
	EnemyStatus enemyStatus;
	public GameObject flameEffect;

	// Use this for initialization
	void Start () {
		enemy = GameObject.Find ("Enemy");
		enemyStatus = enemy.GetComponent<EnemyStatus> ();
		enemyMover = enemy.GetComponent<EnemyMover> ();
		playerStatus = GetComponent<PlayerStatus> ();
		playermover = GetComponent<PlayerMover> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	public void Flame (){
		float dis = Vector3.Distance (playermover.movingPos, enemyMover.enemyPos);
		if (dis <= 6 && playerStatus.playerMp >= 7) {
			playerStatus.playerMp -= 7;
			int damage;
			damage = playerStatus.playerPower + Random.Range (8, 13);
			Instantiate (flameEffect, enemy.transform.position, enemy.transform.rotation);
			enemyStatus.EnemyDamage (damage);
		}
	}
}
