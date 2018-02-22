using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveState :BallState {

	public void doAction(Ball b)
	{
		if (b.transform.position.y < -15f) 
		{
			if (b.player.Lives > 0) 
			{
				b.Rigbody.isKinematic = true;
				GameController.getInstance ().LoseChance ();
			}
			b.ActualBallState = b.BallStates [0];
		}
		if (GameController.getInstance ().NumOfCubes <= 0) {
			b.Rigbody.isKinematic = true;
			b.ActualBallState = b.BallStates [2];
		}
			
	}
}
