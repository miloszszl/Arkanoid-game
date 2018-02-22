using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Collections.Specialized;

public class TextConverter : MonoBehaviour {

	public static List<KeyValuePair<string,int>> strToOrderedStructure(string text)
	{
        List<KeyValuePair<string, int>> d = new List<KeyValuePair<string, int>>();
		string[] textArray = text.Split ('\n');

		string[] nick_and_score;
		foreach (string s in textArray) 
		{
			if(s!="")
			{
				nick_and_score=s.Split(' ');
                d.Add(new KeyValuePair<string, int>(nick_and_score[0], int.Parse(nick_and_score[1])));
			}
		}

		if(d.Count == 0) 
		{
			throw new Exception ("No results");
		}
		else 
		{
			var myList = d.ToList ();
			myList.Sort ((p1, p2) => p2.Value.CompareTo (p1.Value));
			return myList;
		}
	}
	
}
