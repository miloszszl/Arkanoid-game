using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;

public class SleepState :BallState {

	public void doAction(Ball b)
	{
		if (b.player.platform != null) {
			Vector3 v = b.BallPosition;
			v.x = b.player.platform.transform.position.x;
			b.transform.position = v;
		}
		if (GameController.getInstance ().scoreText.enabled == false) {
			b.ActualBallState = b.BallStates [0];
		}
	}
		

}
