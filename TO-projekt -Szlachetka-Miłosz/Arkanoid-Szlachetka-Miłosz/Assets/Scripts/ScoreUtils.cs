using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Specialized;
using System.IO;
public class ScoreUtils : MonoBehaviour {

	private static string scoresFileName="Scores.txt";
	public static string ScoresFileName
	{
		get{ return scoresFileName; }
		set{ scoresFileName = value; }
	}

	public static string GetScoresFromDB(string path)
	{
        try
        {
            Console.WriteLine(path + "/" + scoresFileName);
            using (StreamReader sr = new StreamReader(path+"/" + scoresFileName))
            {
                String line = sr.ReadToEnd();
                return line;
            }
        }
        catch (Exception e)
        {
            string communicate = "The file could not be read";
            //Debug.Log(e.Message);
            return communicate;
        }
	}

	public static void SaveResultIfHighEnought(string path,Player player)
	{
        string s = GetScoresFromDB(path);
		List<KeyValuePair<string,int>> d=null;
		try
		{
			d=TextConverter.strToOrderedStructure (s);
		}
		catch(IndexOutOfRangeException) 
		{
			Debug.Log ("Blad.Nie mozna odczytac pliku.");
			return;
		}
		int numOfElements = d.Count;
		if (numOfElements >= 15)
		if (d[numOfElements-1].Value <= player.Score) 
		{
			d.RemoveAt (numOfElements - 1);
		}
		d.Add (new KeyValuePair<string,int>(player.Nick, player.Score));
		string allScores="";
		bool flag = true;
		foreach (KeyValuePair<string,int> x in d) 
		{
			if (flag == true) 
			{
				flag = false;
				allScores+=x.Key + " " + x.Value;
				continue;
			}
			allScores += Environment.NewLine+x.Key + " " + x.Value;
		}

        List<KeyValuePair<string,int>> e= TextConverter.strToOrderedStructure(allScores);
        allScores = "";
        flag = true;
        foreach (KeyValuePair<string, int> x in e)
        {
            if (flag == true)
            {
                flag = false;
                allScores += x.Key + " " + x.Value;
                continue;
            }
            allScores += Environment.NewLine + x.Key + " " + x.Value;
        }

        System.IO.StreamWriter file = new System.IO.StreamWriter(path + "/" + scoresFileName);
        file.WriteLine(allScores);

        file.Close();
	}
}
