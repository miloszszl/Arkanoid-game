using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotStrategy : PlayStrategy {

	public void move(Platform p)
	{
		GameController gc = GameController.getInstance ();
		float xPos = gc.ball.transform.position.x;
		/*if(gc.ball.transform.position.x>8.5f)
			xPos = GameController.getInstance ().ball.transform.position.x-1.5f;
		else if(gc.ball.transform.position.x<-8.5f)
			xPos = GameController.getInstance ().ball.transform.position.x+1.5f;
		else*/
		p.PlatformPos = new Vector3 (Mathf.Clamp (xPos, gc.mapBoundaries[0], gc.mapBoundaries[1]), -9.5f, 0);
		p.transform.position = p.PlatformPos;
	}
}
