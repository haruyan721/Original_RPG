using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldEnemyScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (Random.Range (-25, 25), 0.725f, Random.Range (-25, 25));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
