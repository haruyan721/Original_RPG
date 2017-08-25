using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeMoveScript : MonoBehaviour {
	private Rigidbody _rigidbody;
	// Use this for initialization
	void Start () {
		if (SceneManager.GetActiveScene ().name == "Clear") {
			_rigidbody = GetComponent<Rigidbody> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (SceneManager.GetActiveScene ().name == "Title") {
			transform.Rotate (-0.5f, -0.2f, -0.5f);
		} else if (SceneManager.GetActiveScene ().name == "Field") {
			transform.Rotate (-0.5f, 0, 0);
		}

	}
	void OnCollisionEnter (Collision col){
		if (SceneManager.GetActiveScene ().name == "Clear") {
			_rigidbody.velocity = new Vector3 (0, 3, 0);
		}
	}
}
