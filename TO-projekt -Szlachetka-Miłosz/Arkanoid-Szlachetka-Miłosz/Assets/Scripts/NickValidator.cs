using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NickValidator  {

	public static void CheckNick(string nick)
	{
		
		nick = nick.Trim ();
		nick = nick.Replace (" ", "");
		if (nick.Length == 0)
		{
			throw new Exception ("To short");
		}
		else if (nick.Length > 20)
		{
			throw new Exception ("To long (limit: 20 chars)");
		}
	}
}