using UnityEngine;
using System.Collections;

public class EnemyMover : MonoBehaviour {
	
	public int enemyComandcheck; //行動したかどうかの判定
	private Rigidbody _rigidbody; //Rigidbody
	public Vector3 enemyPos; //自分の座標
	public int enemyMovecheck; //移動したかどうかの判定
	GameObject turnManagement; //ターン判定するオブジェクト
	public TurnManager turnManager; //turnManagerを入れる用
	GameObject player; //デバッグ用のプレイヤー取得

	void Start () {
		player = GameObject.Find ("Player");
		turnManagement = GameObject.Find("TurnManagement");
		turnManager = turnManagement.GetComponent<TurnManager> ();
		_rigidbody = GetComponent<Rigidbody> ();
		if (turnManager.enemyTurnNum != turnManager.turncount) {
			_rigidbody.constraints = RigidbodyConstraints.FreezeAll;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (turnManager.enemyTurnNum == turnManager.turncount && enemyMovecheck == 0) {
			_rigidbody.constraints = RigidbodyConstraints.None;
			_rigidbody.constraints = RigidbodyConstraints.FreezePositionY |
			RigidbodyConstraints.FreezeRotationX |
			RigidbodyConstraints.FreezeRotation;
			//transform.Rotate (new Vector3 (0, Random.Range (-180, 180), 0));
			transform.LookAt (player.transform);
			gameObject.GetComponent<Rigidbody> ().velocity = transform.forward * Random.Range (20f, 30f);
			enemyMovecheck++;
		} 

		enemyPos = this.transform.position; //敵の位置を取得

		if (enemyComandcheck == 1 && enemyMovecheck == 1 && turnManager.turncount == turnManager.enemyTurnNum) {
			turnManager.Next ();
			enemyComandcheck = 0;
			enemyMovecheck = 0;
		}
	}
}
