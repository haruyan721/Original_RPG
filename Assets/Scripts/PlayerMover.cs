using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour {
	
	private Rigidbody _rigidbody;
	private Vector3 _screenPoint; //マウス移動用の変数（１）
	private Vector3 _offset; //マウス移動用の変数（２）
	bool originalCheck; //初期位置を取得したかの判定
	float originalDis; //初期位置と移動した時の位置との距離を測る
	GameObject turnManagement; //ターンを管理するオブジェクト
	public TurnManager turnManager; //TurnManagerを入れる用
	public Vector3 movingPos; //移動した後の座標
	Vector3 originalPos; //初期位置の座標

	void Start () {
		
		turnManagement = GameObject.Find ("TurnManagement"); //ターン用のオブジェクトを取得
		turnManager = turnManagement.GetComponent<TurnManager> (); //turnManagerにTurnManagerを代入
		_rigidbody = GetComponent<Rigidbody> ();

	}


	void Update () {
		
		movingPos = this.transform.position; //自分の現在の座標を取得

	}

	void OnMouseDown(){ //プレイヤーをマウスで動かす処理（１）
		
		if (turnManager.playerTurnNum == turnManager.turncount) {
			
			_rigidbody.constraints = RigidbodyConstraints.None;
			_rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
			_rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
			Vector3 currentScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z);
			this._screenPoint = Camera.main.WorldToScreenPoint (transform.position);
			this._offset = transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z));

		}

	}

	void OnMouseDrag(){ //プレイヤーをマウスで動かす処理（２）
		
		if (turnManager.playerTurnNum == turnManager.turncount) {
			
			_rigidbody.constraints = RigidbodyConstraints.None;
			_rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
			_rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
			Vector3 currentScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z);
			Vector3 currentPosition = Camera.main.ScreenToWorldPoint (currentScreenPoint) + this._offset;
			transform.position = currentPosition;

		}

	}

}
