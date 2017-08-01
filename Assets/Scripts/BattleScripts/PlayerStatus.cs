using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {
	
	public static int playerSpeed = 5; //素早さ
	public static int playerPower = 8; //攻撃力
	public static int playerHp; //HP
	public static int playerMp; //MP
	public static int maxPlayerHp = 30; //最大HP
	public static int maxPlayerMp = 12; //最大MP
	public static int playerDefense =  3; //防御力
	public static int exp = 0; //経験値
	public static int gold = 0; //お金
	/*static public int playerHpTank = 100;
	static public int playerMpTank = 30;
	static public int expTank = 0;
	static public int goldTank = 0;*/

	void Awake(){
		playerHp = maxPlayerHp;
		playerMp = maxPlayerMp;
		if (PlayerPrefs.GetInt ("saveCheck") == 1 && PlayerFieldMoveScript.sceneStart == 0) {
			playerHp = PlayerPrefs.GetInt ("hpSaveDate");
			playerMp = PlayerPrefs.GetInt ("mpSaveDate");
			playerPower = PlayerPrefs.GetInt ("powerSaveDate");
			playerDefense = PlayerPrefs.GetInt ("defenceSaveDate");
			playerSpeed = PlayerPrefs.GetInt ("speedSaveDate");
			exp = PlayerPrefs.GetInt ("expSaveDate");
			gold = PlayerPrefs.GetInt ("goldSaveDate");
			maxPlayerHp = PlayerPrefs.GetInt ("maxHpSaveDate");
			maxPlayerMp = PlayerPrefs.GetInt ("maxMpSaveDate");
			//StatusStorageExport ();
		}
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void HPDamage(int Damage){
		int blockPoint = playerDefense + Random.Range (-3, 1);
		playerHp -= Damage-blockPoint;
	}

	public void BattleBonusGet(){
		exp += 20;
		gold += 50;
	}

	/*public void StatusStorageInport(){
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
	}*/

}
