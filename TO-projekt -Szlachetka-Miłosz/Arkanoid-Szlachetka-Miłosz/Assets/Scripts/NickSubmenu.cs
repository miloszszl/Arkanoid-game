using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NickSubmenu : MonoBehaviour {

	private Canvas levelSubmenu;
	public Canvas subMenu;
	public InputField nickInput;

	public Canvas LevelSubmenu
	{
		get{ return levelSubmenu; }
		set{ levelSubmenu = value; }
	}

	void Start () {
		subMenu= subMenu.GetComponent<Canvas> ();
		subMenu.enabled = true;
		nickInput = nickInput.gameObject.GetComponent<InputField> ();
	}

	private void LoadScene1()
	{
		SceneManager.LoadScene ("1");
	}

	public void OkOnClick()
	{
		InputField input = gameObject.GetComponent<InputField> ();
		string inputText = input.text;
		UserDataMonostate.Nick = inputText;
		Debug.Log (inputText);
		LoadScene1 ();
	}

	public void CancelOnClick()
	{
		this.enabled = false;
	}
}
