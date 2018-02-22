using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Specialized;
using System;

public class GameController : MonoBehaviour {


	public Ball ball;
	public Player player;
	public Text livesText;
	public Text scoreText;
	public Text bonusInfo;
	public GameObject gameOverNotyfication;
	public GameObject youWonNotyfication;
	public GameObject mapCreator;
	private int difficultyLevel;
	private PlayStrategy playStrategy;
	public float[] mapBoundaries;

	public void ShowBonusMessage(string message)
	{
		bonusInfo.text = message;
		bonusInfo.enabled = true;
	}
	public void HideBonusMessage(float delay=2f)
	{
		Invoke ("hideBonusText", delay);
	}
	private void hideBonusText()
	{
		bonusInfo.text ="";
		bonusInfo.enabled =false;
	}

	private int numOfCubes=999;

	private static GameController instance = null;

	private GameController(){}

	public static GameController getInstance()
	{
		if (instance == null) {
			instance = new GameController ();
		}
		return instance;
	}

	public int NumOfCubes
	{
		get{ return numOfCubes; }
		set{ numOfCubes = value; }
	}

	void Awake ()
	{
		gameOverNotyfication.SetActive (false);
		youWonNotyfication.SetActive (false);
		scoreText.enabled = false;
		if (instance == null)
			instance = this;
		else if (instance != null)
			Destroy (gameObject);
		Setup ();

	}

	private void Setup()
	{
		mapBoundaries=new float[]{-8f,8f};
		difficultyLevel=UserDataMonostate.DifficultyLevel;
		player = player.GetComponent<Player> ();
		player.Nick = UserDataMonostate.Nick;
		player.Lives = 3;
		player.Score = 0;
		player.platform=Instantiate (player.platform, transform.position, Quaternion.AngleAxis(90,Vector3.forward));
		//difficultyLevel = 1;	//for test use
		if (difficultyLevel == 1)
			playStrategy = new EasyPlayStrategy ();
		else
			playStrategy = new HardPlayStrategy ();
		
		//playStrategy = new BotStrategy ();
		player.platform.PlayStrategy = playStrategy;
		ball = Instantiate (ball, transform.position, Quaternion.identity);
		ball.player= player;
	}

	private void GameOverChecker()
	{
		if (player.Lives <= 0) 
		{
			gameOverNotyfication.SetActive (true);
			scoreText.enabled = true;
			scoreText.text = "SCORE: " + player.Score;
			ScoreUtils.SaveResultIfHighEnought (Application.dataPath,player);
			Invoke ("GameRestart", 3);
		}
		else 
		{
			return;
		}
	}
	private void WinCheck()
	{
		if (numOfCubes <= 0) 
		{
			youWonNotyfication.SetActive (true);
			scoreText.enabled = true;
			scoreText.text = "SCORE: " + player.Score+"\n Next LEVEL";
			Invoke ("NextLevel", 3);
		}
		else
			return;
	}

	public void DeleteCube()
	{
		numOfCubes--;
		WinCheck();
	}


	private void GameRestart()
	{
		SceneManager.LoadScene ("1");
	}

	private void NextLevel()
	{
		Instantiate (mapCreator, transform.position, Quaternion.identity);
		player.platform.transform.localScale=new Vector3 (0.5f, 3f, 1f);
		youWonNotyfication.SetActive (false);
		scoreText.enabled = false;
	}

	public void LoseChance()
	{
		player.Lives--;
		livesText.text ="Lives: "+player.Lives;
		GameOverChecker ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Escape))
		{
			ScoreUtils.SaveResultIfHighEnought (Application.dataPath,player);
			SceneManager.LoadScene ("startScene");
		}
	}
}
