using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicSingleton : MonoBehaviour{

	private BackgroundMusicSingleton(){}
	private static BackgroundMusicSingleton instance;
	public new AudioSource audio;

	void Awake()
	{
		Instance ();
	}

	public BackgroundMusicSingleton Instance()
	{
		if (instance == null) {
			
			instance = new BackgroundMusicSingleton ();
			audio = audio.GetComponent<AudioSource> ();
			audio.loop = true;
			audio.Play ();
			DontDestroyOnLoad (this.gameObject);
			return instance;
		} 
		else if (instance != null && instance != this) 
		{
			Destroy (this.gameObject);
			return null;
		}
		else 
		{
			return instance;
		}
	}

}
