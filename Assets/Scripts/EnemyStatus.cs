using UnityEngine;
using System.Collections;

public class EnemyStatus : MonoBehaviour {
	
	public int enemySpeed = 20; //素早さ
	public int enemyPower = 8; //攻撃力
	public int enemyHp = 100; //体力

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyHp <= 0) {
			Destroy (this.gameObject);
		}
	}

	public void EnemyDamage(int damage){
		enemyHp -= damage;
	}
}
