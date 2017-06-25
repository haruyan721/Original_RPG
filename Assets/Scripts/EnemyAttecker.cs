using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttecker : MonoBehaviour {
	
	private Rigidbody _rigidbody;
	PlayerHPbarManagement playerHPbarManagement;
	EnemyStatus enemyStatus;
	GameObject player;
	GameObject turnManagement;
	public TurnManager turnManager;
	public PlayerMover playermover;
	public EnemyMover enemyMover;

	// Use this for initialization
	void Start () {
		
		turnManagement = GameObject.Find("TurnManagement");
		player = GameObject.Find ("Player");
		turnManager = turnManagement.GetComponent<TurnManager> ();
		playermover = player.GetComponent<PlayerMover> ();
		playerHPbarManagement = player.GetComponent<PlayerHPbarManagement> ();
		enemyMover = GetComponent<EnemyMover> ();
		enemyStatus = GetComponent<EnemyStatus> ();
		_rigidbody = GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (turnManager.enemyTurnNum == turnManager.turncount && _rigidbody.velocity == new Vector3 (0, 0, 0) && enemyMover.enemyComandcheck == 0 && enemyMover.enemyMovecheck == 1) {
			_rigidbody.constraints = RigidbodyConstraints.FreezeAll;
			float dis = Vector3.Distance (playermover.movingPos, enemyMover.enemyPos);
			if(dis <= 3f && enemyMover.enemyComandcheck == 0){
				int damage = enemyStatus.enemyPower + Random.Range (0, 4);
				playerHPbarManagement.HPDamage (damage);
			}
			enemyMover.enemyComandcheck++;
		}
}
}
