using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttecker : MonoBehaviour {

	private Rigidbody _rigidbody;
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
		enemyMover = GetComponent<EnemyMover> ();
		_rigidbody = GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (turnManager.enemyTurnNum == turnManager.turncount && _rigidbody.velocity == new Vector3 (0, 0, 0) && enemyMover.attackcheck == 0 && enemyMover.movecheck == 1) {
			Debug.Log ("1step");
			_rigidbody.constraints = RigidbodyConstraints.FreezeAll;
			float dis = Vector3.Distance (playermover.movingPos, enemyMover.enemyPos);
			if(dis <= 3f){
				Debug.Log("attack!");
			}

		}
}
}
