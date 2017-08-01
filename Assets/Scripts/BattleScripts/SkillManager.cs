using UnityEngine;
using System.Collections;

public class SkillManager : MonoBehaviour {

	GameObject enemy;
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
		playermover = GetComponent<PlayerMover> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	public void Flame (){
		float dis = Vector3.Distance (playermover.movingPos, enemyMover.enemyPos);
		if (dis <= 6 && PlayerStatus.playerMp >= 3) {
			PlayerStatus.playerMp -= 3;
			int damage;
			damage = PlayerStatus.playerPower + Random.Range (4, 7);
			Instantiate (flameEffect, enemy.transform.position, enemy.transform.rotation);
			enemyStatus.EnemyDamage (damage);
			playermover.playercomandcheck = 1;
		}
	}

	public void Wind(){
		float dis = Vector3.Distance (playermover.movingPos, enemyMover.enemyPos);
		if (dis <= 4 && PlayerStatus.playerMp >= 5) {
			PlayerStatus.playerMp -= 5;
			int damage;
			damage = PlayerStatus.playerPower + Random.Range (1, 4);
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
