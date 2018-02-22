using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class menuScript : MonoBehaviour {

	public Canvas exitSubmenu;
	public Button playButton;
	public Button scoreButton;
	public Button exitButton;
	public Canvas levelSubmenu;
	public Canvas nickSubmenu;
	public InputField nickInput;
	public Text text;
	public Canvas scoreBoard;
	public Text scores;

	// Use this for initialization
	void Start () {
		exitSubmenu = exitSubmenu.GetComponent<Canvas> ();
		playButton = playButton.GetComponent<Button> ();
		exitButton = exitButton.GetComponent<Button> ();
		levelSubmenu = levelSubmenu.GetComponent<Canvas> ();
		nickSubmenu = nickSubmenu.GetComponent<Canvas> ();
		nickInput = nickInput.GetComponent<InputField> ();
		text = text.GetComponent<Text> ();
		scoreBoard = scoreBoard.GetComponent<Canvas> ();
		scoreBoard.enabled = false;
		exitSubmenu.enabled = false;
		levelSubmenu.enabled = false;
		nickSubmenu.enabled = false;
		scores = scores.GetComponent<Text> ();
	}

	public void ExitButtonOnClick()
	{
		exitSubmenu.enabled = true;
		playButton.gameObject.SetActive (false);
		scoreButton.gameObject.SetActive (false);
		exitButton.gameObject.SetActive (false);
	}

	public void NoPress()
	{
		exitSubmenu.enabled = false;
		exitButton.gameObject.SetActive (true);
		playButton.gameObject.SetActive (true);
		scoreButton.gameObject.SetActive (true);

	}

	public void PlayButtonOnClick()
	{
		levelSubmenu.enabled = true;
		exitButton.gameObject.SetActive (false);
		playButton.gameObject.SetActive (false);
		scoreButton.gameObject.SetActive (false);
	}

	public void ExitGame()
	{
		Application.Quit ();
	}

	private void LoadScene1()
	{
		SceneManager.LoadScene ("1");
	}

	public void EasyOnClick()
	{
		UserDataMonostate.DifficultyLevel = 1;
		nickSubmenu.enabled = true;
		levelSubmenu.enabled = false;

	}

	public void HardOnClick()
	{
		UserDataMonostate.DifficultyLevel = 2;
		nickSubmenu.enabled = true;
		levelSubmenu.enabled = false;
	}

	public void OkOnClick()
	{
		string inputText = nickInput.text;
		try
		{
			NickValidator.CheckNick(inputText);
		}
		catch(Exception e) 
		{
			text.text=e.Message;
			return;
		}

		UserDataMonostate.Nick = inputText;
		//Debug.Log (UserDataMonostate.Nick);
		LoadScene1 ();
	}

	public void CancelOnClick()
	{
		nickSubmenu.enabled = false;
		playButton.gameObject.SetActive (true);
		scoreButton.gameObject.SetActive (true);
		exitButton.gameObject.SetActive (true);
	}

	public void ScoreOnClick()
	{
		scoreBoard.enabled = true;
		exitButton.gameObject.SetActive (false);
		playButton.gameObject.SetActive (false);
		scoreButton.gameObject.SetActive (false);
		string scoresContent=ScoreUtils.GetScoresFromDB(Application.dataPath);
		scores.text = scoresContent;

	}

	public void ScoreOkOnClick()
	{
		scoreBoard.enabled = false;
		exitButton.gameObject.SetActive (true);
		playButton.gameObject.SetActive (true);
		scoreButton.gameObject.SetActive (true);
	}

}
