using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	private float platformSpeed=1f;
	private PlayStrategy playStrategy=null;
	private Vector3 platformPos=new Vector3(0,-9.5f,0);

	public Vector3 PlatformPos
	{
		get{return this.platformPos;}
		set{this.platformPos=value;}
	}

	public float PlatformSpeed
	{
		get{return this.platformSpeed;}
		set{this.platformSpeed=value;}
	}

	public PlayStrategy PlayStrategy
	{
		get{return this.playStrategy;}
		set{this.playStrategy=value;}
	}

	private void move()
	{
		if (playStrategy != null)
			playStrategy.move (this);
	}

	// Update is called once per frame
	void Update () {
		move();
	}
}
