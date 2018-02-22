using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDataMonostate{

	private static int difficultyLevel;
	private static string nick;

	public static int DifficultyLevel
	{
		get{ return difficultyLevel; }
		set{ difficultyLevel = value; }
	}
	public static string Nick
	{
		get{ return nick; }
		set{ nick = value; }
	}

}

