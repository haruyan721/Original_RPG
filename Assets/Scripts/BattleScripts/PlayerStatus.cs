using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {
	
	public int playerSpeed = 10; //素早さ
    public int playerPower = 15; //攻撃力
	public int playerHp = 100; //HP
	public int playerMp = 30; //MP
	public int playerDefense =10; //防御力
	public int exp = 0; //経験値
	public int gold = 0; //お金
	static public int playerHpTank = 100;
	static public int playerMpTank = 30;
	static public int expTank = 0;
	static public int goldTank = 0;

	void Awake(){
		if (PlayerPrefs.GetInt ("saveCheck") == 1 && PlayerFieldMoveScript.sceneStart == 0) {
			playerHpTank = PlayerPrefs.GetInt ("hpSaveDate");
			playerMpTank = PlayerPrefs.GetInt ("mpSaveDate");
			expTank = PlayerPrefs.GetInt ("expSaveDate");
			goldTank = PlayerPrefs.GetInt ("goldSaveDate");
			StatusStorageExport ();
		}
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void HPDamage(int Damage){
		playerHp -= Damage;
	}

	public void BattleBonusGet(){
		exp += 20;
		gold += 50;
	}

	public void StatusStorageInport(){
		Debug.Log ("inport");
		playerHpTank = playerHp;
		playerMpTank = playerMp;
		expTank = exp;
		goldTank = gold;
	}

	public void StatusStorageExport(){
		Debug.Log ("export");
		playerHp = playerHpTank;
		playerMp = playerMpTank;
		exp = expTank;
		gold = goldTank;
	}

}
