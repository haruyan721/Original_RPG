using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPbarManagement : MonoBehaviour {

	private Slider _enemyHpDraw;
	public EnemyStatus enemyStatus;
	GameObject enemyHpBar;
	float enemyHpProportion;
	int maxEnemyHp;

	// Use this for initialization
	void Start () {
		enemyHpBar = GameObject.Find ("EnemyHp");
		_enemyHpDraw = enemyHpBar.GetComponent<Slider> ();
		enemyStatus = GetComponent<EnemyStatus> ();
		maxEnemyHp = enemyStatus.enemyHp;
	}
	
	// Update is called once per frame
	void Update () {
		enemyHpProportion = (float)enemyStatus.enemyHp /(float)maxEnemyHp ;
		_enemyHpDraw.value = enemyHpProportion;
	}
		
}
