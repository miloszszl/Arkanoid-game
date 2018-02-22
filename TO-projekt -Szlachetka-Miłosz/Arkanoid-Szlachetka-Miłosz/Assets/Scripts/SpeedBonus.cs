using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBonus: Bonus {

	float speed=150f;

	public void ActivateBonus()
	{
		Vector3 v = GameController.getInstance ().ball.Rigbody.velocity;
		if (v.x > 0)
			GameController.getInstance ().ball.Rigbody.AddForce (new Vector3 (speed, 0, 0));
		if(v.x<0)
			GameController.getInstance ().ball.Rigbody.AddForce (new Vector3 (-speed, 0, 0));
		if (v.y > 0)
			GameController.getInstance ().ball.Rigbody.AddForce (new Vector3 (0, speed, 0));
		if(v.y<0)
			GameController.getInstance ().ball.Rigbody.AddForce (new Vector3 (0,-speed, 0));
		GameController.getInstance ().ShowBonusMessage ("BALL SPEED+");
		GameController.getInstance ().HideBonusMessage();
	}

}
