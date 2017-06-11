using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MouceDrugScript : MonoBehaviour {
	private Renderer rangeRend;
	private Rigidbody _rigidbody;
	private Vector3 _screenPoint;
	private Vector3 _offset;
	private Slider _hpDrow;
	private Slider _mpDrow;
	public static Vector3 originalpos;
	public static int menber = 2; 
	public static int speed = 10; 
	public static int hp = 100;
	public static int mp = 35;
	public static int turncount = 1;
	public int buttonPopUpCheck = 0;
	public int turncheck;
	public int guardDamage;
	int blockcheck = 0;
	int commandcheck = 0;
	int originalcheck = 0; 
	string turntext;
	float originaldis;
	public Text turnwindow;
	public GameObject hitEfect;
	public GameObject enemy;
	public GameObject nextbutton;
	public GameObject skillbutton1;
	public GameObject skillbutton2;
	Vector3 movingpos;
	GameObject moverange;
	GameObject hpBar;
	GameObject mpBar;

	// Use this for initialization
	void Start () {
		buttonPopUpCheck = 0;
		hpBar = GameObject.Find("HP");
		mpBar = GameObject.Find("MP");
		enemy = GameObject.Find ("Enemy");
		moverange = GameObject.Find ("sarcle");
		_hpDrow = hpBar.GetComponent <Slider> ();
		_mpDrow = mpBar.GetComponent<Slider> ();
		rangeRend = moverange.GetComponent<Renderer> (); 
		_rigidbody = GetComponent<Rigidbody> ();
		nextbutton.SetActive (false);
		skillbutton1.SetActive (false);
		skillbutton2.SetActive (false);
		if (EnemyMoveScript.enemySpeed <= speed) {
			turncheck = 1;
		} else {
			turncheck = 2;
			_rigidbody.constraints = RigidbodyConstraints.FreezeAll;
		}

	}
	
	// Update is called once per frame
	void Update () {
		moverange.transform.position = originalpos;
		movingpos = this.transform.position;
		originaldis = Vector3.Distance (originalpos, movingpos);
		if (turncheck == turncount) {
			turntext = "あなたのターン";
			turnwindow.text = turntext;
			rangeRend.enabled = true;
			if (commandcheck == 0) {
				blockcheck = 0;
			}
		} else {
			turntext = "相手のターン";
			turnwindow.text = turntext;
			rangeRend.enabled = false;
		}
		if (originaldis >= 6f) {
			transform.position = originalpos;
			moverange.transform.position = originalpos;
		}
		if (originalcheck == 0) {
			originalpos = this.transform.position;
			originalcheck++;
		}
		if (turncheck == turncount && commandcheck == 1) {
			nextbutton.SetActive (true);
		}
		_hpDrow.value = hp;
		_mpDrow.value = mp;
	}

	void OnMouseDown(){
		if (turncheck == turncount && commandcheck == 0) {
			_rigidbody.constraints = RigidbodyConstraints.None;
			_rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
			_rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
			this._screenPoint = Camera.main.WorldToScreenPoint (transform.position);
			this._offset = transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z));
		}
	}

	void OnMouseDrag(){
		if (turncheck == turncount && commandcheck == 0) {
			Vector3 currentScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z);
			Vector3 currentPosition = Camera.main.ScreenToWorldPoint (currentScreenPoint) + this._offset;
			transform.position = currentPosition;
		}


	}

	public void NextTurn(){
		if(turncheck == turncount){
		if (turncheck == menber) {
			turncount = 1;
			commandcheck = 0;
			originalcheck = 0;
				nextbutton.SetActive (false);
			_rigidbody.constraints = RigidbodyConstraints.FreezeAll;
		} else {
			turncount++;
			commandcheck = 0;
			originalcheck = 0;
				nextbutton.SetActive (false);
			_rigidbody.constraints = RigidbodyConstraints.FreezeAll;
		}
		}
	}

	public void Attack (){
		if (commandcheck == 0 && buttonPopUpCheck == 0) {
			Vector3 playerPos = this.transform.position;
			Vector3 enemyPos = enemy.transform.position;
			float dis = Vector3.Distance (playerPos, enemyPos);
			if (dis <= 3f) {
				enemy.GetComponent<EnemyMoveScript> ().Damage (Random.Range (10, 15),1);
				commandcheck = 1;
			}
		}
	}

	public void SkillWindowPopUp(){
		if (commandcheck == 0) {
			if (buttonPopUpCheck == 0) {
				skillbutton1.SetActive (true);
				skillbutton2.SetActive (true);
				buttonPopUpCheck = 1;
			} else if (buttonPopUpCheck == 1) {
				skillbutton1.SetActive (false);
				skillbutton2.SetActive (false);
				buttonPopUpCheck = 0;
			}
		}
	}
	public void Skill1(){
		if (commandcheck == 0 && mp >= 8) {
			Vector3 playerPos = this.transform.position;
			Vector3 enemyPos = enemy.transform.position;
			float dis = Vector3.Distance (playerPos, enemyPos);
			if (dis <= 4f) {
				enemy.GetComponent<EnemyMoveScript> ().Damage (Random.Range (20, 25),2);
				skillbutton1.SetActive (false);
				skillbutton2.SetActive (false);
				buttonPopUpCheck = 0;
				commandcheck = 1;
				mp -= 8;
			}
		}
	}

	public void Skill2(){
		if (commandcheck == 0 && mp >= 5) {
			Vector3 playerPos = this.transform.position;
			Vector3 enemyPos = enemy.transform.position;
			float dis = Vector3.Distance (playerPos, enemyPos);
			if (dis <= 4f) {
				enemy.GetComponent<EnemyMoveScript> ().Damage (Random.Range (15, 18),3);
				skillbutton1.SetActive (false);
				skillbutton2.SetActive (false);
				buttonPopUpCheck = 0;
				commandcheck = 1;
				mp -= 5;
			}
		}
	}

	public void Damage(int damagepoint){
		Instantiate (hitEfect,transform.position,transform.rotation);
		if (blockcheck == 1) {
			guardDamage = Random.Range (15, 16);
			hp -= damagepoint - guardDamage;
		} else {
			hp -= damagepoint;
		}
	}

	public void Block(){
		if (commandcheck == 0 && buttonPopUpCheck == 0) {
			blockcheck = 1;
			commandcheck = 1;
		}
	}
}