using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{


public class ScoreBonus : Bonus {

	int score=30;

	public void ActivateBonus()
	{
		GameController.getInstance ().player.Score += score;
		GameController.getInstance ().ShowBonusMessage("+"+score+"POINTS");
		GameController.getInstance ().HideBonusMessage();
	}
}
}
