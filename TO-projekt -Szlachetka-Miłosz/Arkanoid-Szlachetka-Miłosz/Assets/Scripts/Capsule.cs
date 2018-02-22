using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour {

	private Bonus bonus=null;
	public GameObject bonusInfo;

	public Bonus Bonus
	{
		get{ return bonus; }
		set{ this.bonus = value; }
	}

	void OnTriggerEnter(Collider collision)
	{
		if (collision.GetComponent<Collider>().tag == "Platform") 
		{
			if (bonus != null) 
			{
				bonus.ActivateBonus ();
			}
		}
	}

	void Update()
	{
		transform.Rotate (new Vector3 (5, 0, 0));
		if (transform.position.y < -25f)
			Destroy (gameObject);
	}
}
