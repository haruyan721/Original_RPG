using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySponerScript : MonoBehaviour {
	public GameObject enemy;
	public GameObject enemy2;
	GameObject player;
	float timer = 0;
	int interval = 3;
	int enemyRandomNum = 0;
	PlayerFieldMoveScript playerFieldMoveScript;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		playerFieldMoveScript = player.GetComponent<PlayerFieldMoveScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerFieldMoveScript.townMode == 0) {
			timer += Time.deltaTime;
			if (timer >= interval) {
				timer = 0;
				interval = Random.Range (3, 6);
				Sporn ();
			}
		}
	}

	void Sporn(){
		enemyRandomNum = Random.Range (1, 11);
		if (enemyRandomNum <= 8) {
			Instantiate (enemy);
		} else if (enemyRandomNum >= 9) {
			Instantiate (enemy2);
		}
	}
}
