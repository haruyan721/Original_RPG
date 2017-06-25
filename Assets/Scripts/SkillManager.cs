using UnityEngine;
using System.Collections;

public class SkillManager : MonoBehaviour {

	GameObject enemy;
	PlayerStatus playerStatus;
	PlayerMover playermover;
	EnemyStatus enemyStatus;
	SkillWindowPopup skillWindowPopup;


	// Use this for initialization
	void Start () {
		enemy = GameObject.Find ("Enemy");
		enemyStatus = enemy.GetComponent<EnemyStatus> ();
		playerStatus = GetComponent<PlayerStatus> ();
		playermover = GetComponent<PlayerMover> ();
		skillWindowPopup = GetComponent<SkillWindowPopup> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	public void Flame (){
		playerStatus.playerMp -= 7;
		int damage;
		damage = playerStatus.playerPower + Random.Range (8, 13);
		enemyStatus.EnemyDamage (damage);
	}
}
