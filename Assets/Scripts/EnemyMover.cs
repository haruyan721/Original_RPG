using UnityEngine;
using System.Collections;

public class EnemyMover : MonoBehaviour {
	
	public Vector3 myPos;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		myPos = this.transform.position; //敵の位置を取得

	}
}
