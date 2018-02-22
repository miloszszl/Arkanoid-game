using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player:MonoBehaviour{

	private int score;
	private int lives;
	private string nick;
	public Platform platform;
	public AudioSource scoreAudio;
	public AudioSource loseChanceAudio;

	public int Score
	{
		get{ return score; }
		set
		{ 
			score = value;
			if(value>0)scoreAudio.Play();
		}
	}

	public int Lives
	{
		get{ return lives; }
		set
		{ 
			lives = value; 
			if (value != 3)
				loseChanceAudio.Play ();
		}
	}

	public string Nick
	{
		get{ return nick; }
		set{ nick = value; }
	}


	public Player(string nick,int lives=3,int score=0)		//not used because Unity use Instantiate to create objects instead of constructors
	{
		this.score=score;
		this.lives=lives;
		this.nick = nick;
	}

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
