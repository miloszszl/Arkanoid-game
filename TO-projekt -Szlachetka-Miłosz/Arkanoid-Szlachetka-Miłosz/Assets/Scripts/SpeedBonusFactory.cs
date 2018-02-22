using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBonusFactory : BonusFactory {

		public Bonus CreateBonus ()
		{
			return new SpeedBonus ();
		}

}
