using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyPlayStrategy: PlayStrategy{

	public void move(Platform p)
	{
		float xPos = p.transform.position.x + (Input.GetAxis ("Horizontal")*p.PlatformSpeed);
		p.PlatformPos = new Vector3 (Mathf.Clamp (xPos, GameController.getInstance().mapBoundaries[0], GameController.getInstance().mapBoundaries[1]), -9.5f, 0);
		p.transform.position = p.PlatformPos;
	}
}
