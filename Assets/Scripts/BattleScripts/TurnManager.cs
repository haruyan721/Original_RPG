using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TurnManager : MonoBehaviour {

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
		fadePanel = GameObject.Find("FadePanel");
		fadeManager = fadePanel.GetComponent<FadeManager> ();
		battleBonusScript = enemy.GetComponent<BattleBonusScript>();
		fadeManager.fadeName = "BattleStart";
		fadeManager.changeType = 2;
		MenberCheck();

	}


	void Update () {
		if (enemyMenber == 0 && battleEndCheck == 0 && escapeCheck == 0) {
			battleText = "You Win!!";
			battleEndCheck = 1;
			textWindow.text = battleText;
			battleBonusScript.BattleBonusGet ();
			/*PlayerStatus.exp += 20;
			PlayerStatus.gold += 5;*/
			if (PlayerFieldMoveScript.battleEnemy == 3) {
				Invoke ("ClearWait", 2);
			} else {
				Invoke ("FieldBackWait", 2);
			}
		}else if(playerMenber == 0 && battleEndCheck == 0 && escapeCheck == 0){
			battleEndCheck = 1;
			battleText = "You lose…";
			textWindow.text = battleText;
			Invoke ("GameOverWait", 2);
		} else if (escapeCheck == 1) {
			battleEndCheck = 1;
			battleText = "Escape!";
			textWindow.text = battleText;
			Invoke ("FieldBackWait", 2);

		}

	}

	public void Next(){
		
		if (turncount == allMenber && battleEndCheck == 0) {
			turncount = 1;
		} else {
			turncount++;
		}

		if (turncount == playerTurnNum && battleEndCheck == 0) {
			battleText = "your turn"; 
		} else {
			battleText = "enemy turn"; 
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

	public void BattleStart(){
		if (playerSpeedCheck >= enemySpeedCheck) { //どちらが先に動くかの処理

			playerTurnNum = 1; //ターン順の決定
			enemyTurnNum = 2;
			battleText = "your turn"; 
			textWindow.text = battleText;

		} else {

			playerTurnNum = 2; //ターン順の決定
			enemyTurnNum = 1;
			battleText = "enemy turn"; 
			textWindow.text = battleText;

		}
	}
		
}
