using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

	public GameObject capsule;
	public int hitsToKill;
	public int points;
	public GameObject cubeParticle;

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Ball") 
		{
			hitsToKill--;
			if (hitsToKill <= 0) 
			{
				Instantiate (cubeParticle, transform.position, Quaternion.Euler(90,0,0));
				GameController.getInstance ().DeleteCube ();
				GameController.getInstance ().player.Score += points;
				if(Random.Range(0, 10)<3)
				{
					Capsule c=Instantiate (capsule, transform.position, Quaternion.identity).GetComponent<Capsule>();
					BonusFactory bf=null;
					switch (Random.Range (0, 3)) {
					case 0:
						bf = new ScoreBonusFactory ();
						break;
					case 1:
						bf = new PlatformBonusFactory();
						break;
					case 2:
						bf = new SpeedBonusFactory();
						break;
					}
					if(bf!=null)
						c.Bonus = bf.CreateBonus ();
				}
				Destroy (gameObject);

			}
		}
	}

}
