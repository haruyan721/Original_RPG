using UnityEngine;
using System.Collections;

public class SkillManager : MonoBehaviour {

	GameObject enemy;
	PlayerStatus playerStatus;
	PlayerMover playermover;
	EnemyMover enemyMover;
	EnemyStatus enemyStatus;
	Rigidbody enemyRigidbody;
	public GameObject flameEffect;
	public GameObject windEffect;

	// Use this for initialization
	void Start () {
		enemy = GameObject.Find ("Enemy");
		enemyStatus = enemy.GetComponent<EnemyStatus> ();
		enemyMover = enemy.GetComponent<EnemyMover> ();
		enemyRigidbody = enemy.GetComponent<Rigidbody> ();
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
			playermover.playercomandcheck = 1;
		}
	}

	public void Wind(){
		float dis = Vector3.Distance (playermover.movingPos, enemyMover.enemyPos);
		if (dis <= 4 && playerStatus.playerMp >= 8) {
			playerStatus.playerMp -= 8;
			int damage;
			damage = playerStatus.playerPower + Random.Range (6, 10);
			enemyStatus.EnemyDamage (damage);

			enemyRigidbody.constraints = RigidbodyConstraints.None;
			enemyRigidbody.constraints = RigidbodyConstraints.FreezePositionY |
				RigidbodyConstraints.FreezeRotationX |
				RigidbodyConstraints.FreezeRotation;
			enemy.transform.LookAt (transform.position);
			enemy.transform.Rotate (new Vector3 (0, 180, 0));
			enemyRigidbody.velocity = transform.forward * Random.Range (20f, 30f);

			Instantiate (windEffect, enemy.transform.position, enemy.transform.rotation);
			playermover.playercomandcheck = 1;
		}
	} 
}
