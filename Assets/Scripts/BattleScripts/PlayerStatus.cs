using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {

	public static int level = 1;
	public static int playerSpeed = 5; //素早さ
	public static int playerPower = 4; //攻撃力
	public static int playerHp; //HP
	public static int playerMp; //MP
	public static int maxPlayerHp = 30; //最大HP
	public static int maxPlayerMp = 12; //最大MP
	public static int playerDefense =  3; //防御力
	public static int exp = 0; //経験値
	public static int gold = 0; //お金
	public int noHpMax = 0;
	public int noMpMax = 0;


	void Awake(){
		
		if(PlayerFieldMoveScript.sceneStart == 0){
			playerHp = maxPlayerHp;
			playerMp = maxPlayerMp;
		}

		if (PlayerPrefs.GetInt ("saveCheck") == 1 && PlayerFieldMoveScript.sceneStart == 0) {
			level = PlayerPrefs.GetInt ("levelSaveDate");
			playerHp = PlayerPrefs.GetInt ("hpSaveDate");
			playerMp = PlayerPrefs.GetInt ("mpSaveDate");
			playerPower = PlayerPrefs.GetInt ("powerSaveDate");
			playerDefense = PlayerPrefs.GetInt ("defenseSaveDate");
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
		if (playerHp < maxPlayerHp) {
			noHpMax = 1;
		} 
		if (playerMp < maxPlayerMp) {
			noMpMax = 1;
		}
	
	}

	public void HPDamage(int Damage){
		int blockPoint = playerDefense + Random.Range (-3, 1);
		if (Damage <= blockPoint) {
			playerHp = playerHp - 1;
		} else {
			playerHp -= Damage - blockPoint;
		}
	}


}
