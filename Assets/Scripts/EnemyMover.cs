using UnityEngine;
using System.Collections;

public class EnemyMover : MonoBehaviour {

	private Rigidbody _rigidbody; //Rigidbody
	public Vector3 enemyPos; //自分の座標
	public int attackcheck; //攻撃したかどうかの判定
	public int movecheck; //移動したかどうかの判定
	GameObject turnManagement; //ターン判定するオブジェクト
	public TurnManager turnManager; //turnManagerを入れる用

	void Start () {

		turnManagement = GameObject.Find("TurnManagement");
		turnManager = turnManagement.GetComponent<TurnManager> ();
		_rigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (turnManager.enemyTurnNum == turnManager.turncount && movecheck == 0) {
			_rigidbody.constraints = RigidbodyConstraints.None;
			_rigidbody.constraints = RigidbodyConstraints.FreezePositionY |
				RigidbodyConstraints.FreezeRotationX |
				RigidbodyConstraints.FreezeRotation;
			transform.Rotate (new Vector3 (0, Random.Range (-180, 180), 0));
			gameObject.GetComponent<Rigidbody> ().velocity = transform.forward * Random.Range (20f, 30f);
			movecheck++;
		}

		enemyPos = this.transform.position; //敵の位置を取得

	}
}
