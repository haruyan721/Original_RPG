using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldEnemyScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (Random.Range (-10, 11), 0.725f, Random.Range (-10, 11));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
