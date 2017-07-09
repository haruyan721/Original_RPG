using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySponerScript : MonoBehaviour {
	public GameObject enemy;
	float timer = 0;
	int interval = 3;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= interval) {
			timer = 0;
			interval = Random.Range(3,6);
			Sporn ();
		}
	}

	void Sporn(){
		Instantiate (enemy);
	}
}
