using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyMoveScript : MonoBehaviour {
	GameObject player;
	GameObject hpBar;
	Transform playertransform;
	//MouceDrugScript mouceDrugScript;
	public GameObject hitEffect;
	public GameObject fireEffect;
	public GameObject windEffect;
	private Rigidbody _rigidbody;
	private Slider _hpDrow;
	public static int enemyHp = 100;
	public static int enemySpeed = 0;
	public int enemyturncheck;
	int attackcheck = 0;
	int movecheck = 0;
	// Use this for initialization

	void Awake (){
		player = GameObject.Find ("Player");
		hpBar = GameObject.Find ("EnemyHp");
		playertransform = player.GetComponent<Transform> ();
		//mouceDrugScript = GetComponent<MouceDrugScript>();
		_rigidbody = GetComponent<Rigidbody> ();
		_hpDrow = hpBar.GetComponent<Slider> ();
		enemySpeed = Random.Range (8, 13);
	}

	void Start () {
		if (MouceDrugScript.speed < enemySpeed) {
			enemyturncheck = 1;
		} else {
			enemyturncheck = 2;
			_rigidbody.constraints = RigidbodyConstraints.FreezeAll;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (MouceDrugScript.turncount == enemyturncheck) {
			if (movecheck == 0) {
				EnemyMove ();
				movecheck++;
			}
		}
		if (_rigidbody.velocity == new Vector3 (0, 0, 0) && MouceDrugScript.turncount == enemyturncheck) {
			_rigidbody.constraints = RigidbodyConstraints.FreezeAll;
			Vector3 playerpos = player.transform.position;
			Vector3 enemypos = this.transform.position;
			float dis = Vector3.Distance (playerpos, enemypos);
			if (dis <= 3f && attackcheck == 0) {
				player.GetComponent<MouceDrugScript> ().Damage (Random.Range (10, 15));
				//mouceDrugScript.Damage (Random.Range(10,15));
				attackcheck++;
			}
			if (enemyturncheck == MouceDrugScript.menber) {
				MouceDrugScript.turncount = 1;
				attackcheck = 0;
				movecheck = 0;
			} else {
				MouceDrugScript.turncount++;
				attackcheck = 0;
				movecheck = 0;
			}

		}
		_hpDrow.value = enemyHp;
	}

	void EnemyMove(){
		_rigidbody.constraints = RigidbodyConstraints.None;
		_rigidbody.constraints = RigidbodyConstraints.FreezePositionY |
			RigidbodyConstraints.FreezeRotationX |
			RigidbodyConstraints.FreezeRotation;
		transform.Rotate (new Vector3 (0, Random.Range (-180, 180), 0));
		gameObject.GetComponent<Rigidbody> ().velocity = transform.forward * Random.Range (20f, 30f);
	}
	public void Damage(int damagepoint,int attackpattern){
		/*if (damagepoint >= 20) {
			enemyHp -= damagepoint;
			Instantiate (superEfect,transform.position,transform.rotation);
		} else {
			enemyHp -= damagepoint;
			Instantiate (hitEfect,transform.position,transform.rotation);
		}*/
		if (attackpattern == 1) {
			Instantiate (hitEffect, transform.position, transform.rotation);
			enemyHp -= damagepoint;
		} else if (attackpattern == 2) {
			Instantiate (fireEffect, transform.position, transform.rotation);
			enemyHp -= damagepoint;
		} else if (attackpattern == 3) {
			Instantiate (windEffect, transform.position, transform.rotation);
			_rigidbody.constraints = RigidbodyConstraints.None;
			_rigidbody.constraints = RigidbodyConstraints.FreezePositionY |
				RigidbodyConstraints.FreezeRotationX |
				RigidbodyConstraints.FreezeRotation;
			transform.LookAt (playertransform);
			transform.Rotate (new Vector3 (0, 180, 0));
			gameObject.GetComponent<Rigidbody> ().velocity = transform.forward * Random.Range (20f, 30f);
			enemyHp -= damagepoint;
		}
	}
}		