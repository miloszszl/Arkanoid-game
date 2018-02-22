using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBonus :Bonus{

	float size=1f;

	public void ActivateBonus()
	{
		GameController.getInstance ().player.platform.transform.localScale += new Vector3 (0f, size, 0f);
		GameController.getInstance ().mapBoundaries [0] += size/2;
		GameController.getInstance ().mapBoundaries [1] -= size/2;
		GameController.getInstance ().ShowBonusMessage("PLATFORM SIZE+");
		GameController.getInstance ().HideBonusMessage();
	}
}
