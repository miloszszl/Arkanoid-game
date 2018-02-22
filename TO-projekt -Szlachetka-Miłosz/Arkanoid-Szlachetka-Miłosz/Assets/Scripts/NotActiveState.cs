using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotActiveState : BallState {

	public void doAction(Ball b)
	{
		if (b.player.Lives > 0)
		{
			if (Input.GetButtonDown ("Jump") && b.ActualBallState == b.BallStates [0]) {
				b.Rigbody.isKinematic = false;
				b.CalculateBallForce ();
				b.Rigbody.AddForce (b.BallForce);
				b.ActualBallState = b.BallStates [1];
			}

			if (b.player.platform != null) {
				Vector3 v = b.BallPosition;
				v.x = b.player.platform.transform.position.x;
				b.transform.position = v;
			}
		}
	}

}
