using UnityEngine;
using System.Collections;

public class EnemyStatus : MonoBehaviour {
	
	public int enemySpeed; //素早さ
	public int enemyPower; //攻撃力
	public int enemyHp; //体力
	public float enemyMoveRange;
	GameObject turnManagement;
	TurnManager turnManager;

	void Start () {
		turnManagement = GameObject.Find ("TurnManagement");
		turnManager = turnManagement.GetComponent<TurnManager>();

		switch (PlayerFieldMoveScript.battleEnemy) {
		case 1:
			enemySpeed = 8;
			enemyPower = 8;
			enemyHp = 25;
			enemyMoveRange = 15;
			break;
		case 2:
			enemySpeed = 10;
			enemyPower = 12;
			enemyHp = 60;
			enemyMoveRange = 20;
			break;
		case 3:
			enemySpeed = 12;
			enemyPower = 16;
			enemyHp = 130;
			enemyMoveRange = 30;
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyHp <= 0) {
			turnManager.enemyMenber--;
			turnManager.allMenber--;
			Destroy (this.gameObject);
		}
	}

	public void EnemyDamage(int damage){
		enemyHp -= damage;
	}
}
