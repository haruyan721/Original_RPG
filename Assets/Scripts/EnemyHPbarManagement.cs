using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPbarManagement : MonoBehaviour {

	private Slider _enemyHpDraw;
	public EnemyStatus enemyStatus;
	GameObject enemyHpBar;

	// Use this for initialization
	void Start () {
		enemyHpBar = GameObject.Find ("EnemyHp");
		_enemyHpDraw = enemyHpBar.GetComponent<Slider> ();
		enemyStatus = GetComponent<EnemyStatus> ();
	}
	
	// Update is called once per frame
	void Update () {
		_enemyHpDraw.value = enemyStatus.enemyHp;
	}

	public void EnemyDamage(int damage){
		enemyStatus.enemyHp -= damage;
	}
}
