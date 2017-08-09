using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour {
	
	private Rigidbody _rigidbody;
	private Vector3 _screenPoint; //マウス移動用の変数（１）
	private Vector3 _offset; //マウス移動用の変数（２）
	private Renderer _rangerend; //移動範囲の可視化用
	float originalDis; //初期位置と移動した時の位置との距離を測る
	GameObject turnManagement; //ターンを管理するオブジェクト
	GameObject moveRange; //移動範囲
	Vector3 originalPos; //初期位置の座標
	public TurnManager turnManager; //TurnManagerを入れる用
	public Vector3 movingPos; //移動した後の座標
	public int playercomandcheck = 0; //行動したかの判定
	bool originalPoscheck; //初期位置を取得したかの判定

	void Start () {
		
		turnManagement = GameObject.Find ("TurnManagement"); //ターン用のオブジェクトを取得
		turnManager = turnManagement.GetComponent<TurnManager> (); //turnManagerにTurnManagerを代入
		_rigidbody = GetComponent<Rigidbody> ();
		_rigidbody.constraints = RigidbodyConstraints.FreezeAll;
		moveRange = GameObject.Find ("sarcle");
		_rangerend = moveRange.GetComponent<Renderer> ();
		_rangerend.enabled = false;

	}


	void Update () {

		movingPos = this.transform.position; //自分の現在の座標を取得

		if (originalPoscheck == false && turnManager.turncount == turnManager.playerTurnNum) {
			originalPos = this.transform.position;
			originalPoscheck = true;
			_rangerend.enabled = true;
		}
		moveRange.transform.position = originalPos;

		originalDis = Vector3.Distance (originalPos, movingPos);
		if (originalDis >= 6f) {
			transform.position = originalPos;
			moveRange.transform.position = originalPos;
		}
		if (PlayerStatus.playerHp <= 0) {
			Destroy (this.gameObject);
			turnManager.playerMenber--;
		}

	}

	void OnMouseDown(){ //プレイヤーをマウスで動かす処理（１）
		
		if (turnManager.playerTurnNum == turnManager.turncount && playercomandcheck == 0 ) {
			
			_rigidbody.constraints = RigidbodyConstraints.None;
			_rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
			_rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
			//Vector3 currentScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z);
			this._screenPoint = Camera.main.WorldToScreenPoint (transform.position);
			this._offset = transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z));

		}

	}

	void OnMouseDrag(){ //プレイヤーをマウスで動かす処理（２）
		
		if (turnManager.playerTurnNum == turnManager.turncount && playercomandcheck == 0) {
			
			_rigidbody.constraints = RigidbodyConstraints.None;
			_rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
			_rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
			Vector3 currentScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z);
			Vector3 currentPosition = Camera.main.ScreenToWorldPoint (currentScreenPoint) + this._offset;
			transform.position = currentPosition;

		}

	}

	public void resetNext(){
		turnManager.Next ();
		_rigidbody.constraints = RigidbodyConstraints.FreezeAll;
		playercomandcheck = 0;
		originalPoscheck = false;
		_rangerend.enabled = false;
	}

}
