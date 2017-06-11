using UnityEngine;
using System.Collections;

public class EnemyCanvasScript : MonoBehaviour {
	public Camera rotatecamera;
	public GameObject enemy;
	// Use this for initialization
	void Start () {
		rotatecamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = rotatecamera.transform.rotation;
		transform.position = new Vector3 (enemy.transform.position.x, enemy.transform.position.y + 2, enemy.transform.position.z);
	}
}
