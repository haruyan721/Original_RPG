using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TurnManager : MonoBehaviour {

	GameObject player;
	GameObject [] enemys;
	GameObject [] players;
	GameObject enemyPrefab;
	public int turncount = 1; //ターン番号
	public int playerTurnNum; //プレイヤーのターン順
	public int enemyTurnNum; //敵のターン順
	public int playerMenber;
	public int enemyMenber;
	public int escapeCheck;
	public int allMenber = 2;
	int playerSpeedCheck = 0; //プレイヤーのスピードを取得
	int enemySpeedCheck = 0; //敵のスピードを取得
	int battleEndCheck = 0;
	public Text textWindow;
	string battleText;
	GameObject enemy;
	EnemyStatus enemyStatus;
	GameObject fadePanel;
	FadeManager fadeManager;
	BattleBonusScript battleBonusScript;
	LevelUpScript levelUpScript;


	void Awake (){

		switch (PlayerFieldMoveScript.battleEnemy) {

		case 1:
			enemyPrefab = (GameObject)Resources.Load ("Prefabs/Battle_Enemy1");
			Instantiate (enemyPrefab);
			break;

		case 2:
			enemyPrefab = (GameObject)Resources.Load ("Prefabs/Battle_Enemy2");
			Instantiate (enemyPrefab);
			break;

		case 3:
			enemyPrefab = (GameObject)Resources.Load ("Prefabs/Battle_Boss");
			Instantiate (enemyPrefab);
			break;
		}
	}

	void Start () {
		playerSpeedCheck = PlayerStatus.playerSpeed; //素早さを代入
		switch (PlayerFieldMoveScript.battleEnemy) {
		case 1:
			enemy = GameObject.Find("Battle_Enemy1(Clone)"); //敵を取得
			break;
		case 2:
			enemy = GameObject.Find("Battle_Enemy2(Clone)"); //敵を取得
			break;
		case 3:
			enemy = GameObject.Find("Battle_Boss(Clone)"); //敵を取得
			break;
		}

		enemyStatus = enemy.GetComponent<EnemyStatus> (); //敵のステータスから素早さを取得
		enemySpeedCheck = enemyStatus.enemySpeed; //代入
		player = GameObject.Find("Player");
		fadePanel = GameObject.Find("FadePanel");
		fadeManager = fadePanel.GetComponent<FadeManager> ();
		battleBonusScript = enemy.GetComponent<BattleBonusScript>();
		levelUpScript = player.GetComponent<LevelUpScript> ();
		fadeManager.fadeName = "BattleStart";
		fadeManager.changeType = 2;
		MenberCheck();

	}


	void Update () {
		if (enemyMenber == 0 && battleEndCheck == 0 && escapeCheck == 0) {
			battleText = "敵を倒した！";
			battleEndCheck = 1;
			textWindow.text = battleText;
			battleBonusScript.BattleBonusGet ();
			Invoke ("BattleEndproces", 0.1f);

		}else if(playerMenber == 0 && battleEndCheck == 0 && escapeCheck == 0){
			battleEndCheck = 1;
			battleText = "負けてしまった…";
			textWindow.text = battleText;
			Invoke ("GameOverWait", 2);
		} else if (escapeCheck == 1) {
			battleEndCheck = 1;
			battleText = "逃げ出した！";
			textWindow.text = battleText;
			Invoke ("FieldBackWait", 2);

		}

	}

	public void Next(){
		if (playerMenber == 0) {
			battleText = "負けてしまった…";
			textWindow.text = battleText;
		}
		if (turncount == allMenber && battleEndCheck == 0) {
			turncount = 1;
		} else {
			turncount++;
		}

		if (turncount == playerTurnNum && battleEndCheck == 0) {
			battleText = "あなたのターン"; 
		} else {
			battleText = "敵のターン"; 
		}
		textWindow.text = battleText;

	}
		
	void MenberCheck(){
		players = GameObject.FindGameObjectsWithTag("Player");
		playerMenber = players.Length;
		enemys = GameObject.FindGameObjectsWithTag("Enemy");
		enemyMenber = enemys.Length;
		allMenber = playerMenber + enemyMenber;
	}

	void FieldBackWait(){
		//Debug.Log (fadePanel.name);
		fadePanel.SetActive (true);
		FadeManager.fadeSpeed = 0.05f;
		fadeManager.fadeName = "BattleEnd";
		fadeManager.changeType = 1;
	}

	public void FieldBack(){
		//playerStatus.StatusStorageInport ();
		SceneManager.LoadScene ("Field");
	}

	void GameOverWait(){
		fadePanel.SetActive (true);
		FadeManager.fadeSpeed = 0.05f;
		fadeManager.fadeName = "GameOver";
		fadeManager.changeType = 1;
	}

	public void GameOver(){
		SceneManager.LoadScene ("GameOver");
	}

	void ClearWait(){
		fadePanel.SetActive (true);
		FadeManager.fadeSpeed = 0.05f;
		fadeManager.fadeName = "Clear";
		fadeManager.changeType = 1;
	}
	public void Clear(){
		SceneManager.LoadScene ("Clear");
	}

	void LevelUp(){
		levelUpScript.levelUpCheck = 0;
		battleText = "レベルアップ！";
		textWindow.text = battleText;
		Invoke ("FieldBackWait", 2);
	}

	void BattleEndproces (){
		if (PlayerFieldMoveScript.battleEnemy == 3) {
			Invoke ("ClearWait", 2);
		} else if (levelUpScript.levelUpCheck == 1) {
			Debug.Log ("ok");
			Invoke ("LevelUp", 2);
		} else {
			Invoke ("FieldBackWait", 2);
		}
	}

	public void BattleStart(){
		if (playerSpeedCheck >= enemySpeedCheck) { //どちらが先に動くかの処理

			playerTurnNum = 1; //ターン順の決定
			enemyTurnNum = 2;
			battleText = "あなたのターン"; 
			textWindow.text = battleText;

		} else {

			playerTurnNum = 2; //ターン順の決定
			enemyTurnNum = 1;
			battleText = "敵のターン"; 
			textWindow.text = battleText;

		}
	}
		
}
