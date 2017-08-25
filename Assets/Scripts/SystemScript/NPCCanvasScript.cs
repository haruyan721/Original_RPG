using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCanvasScript : MonoBehaviour {
	public Camera rotatecamera;
	public GameObject player;
	// Use this for initialization
	void Start () {
		rotatecamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = rotatecamera.transform.rotation;
		transform.position = new Vector3 (player.transform.position.x, player.transform.position.y + 2, player.transform.position.z + 2);
	}
}
