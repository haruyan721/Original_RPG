using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldEnemyScript : MonoBehaviour {
	
	GameObject player;
	PlayerFieldMoveScript playerFieldMoveScript;
	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (Random.Range (-25, 25), 0.725f, Random.Range (-25, 25));
		player = GameObject.Find ("Player");
		playerFieldMoveScript = player.GetComponent<PlayerFieldMoveScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerFieldMoveScript.townMode == 1) {
			Destroy (this.gameObject);
		}
	}
}
