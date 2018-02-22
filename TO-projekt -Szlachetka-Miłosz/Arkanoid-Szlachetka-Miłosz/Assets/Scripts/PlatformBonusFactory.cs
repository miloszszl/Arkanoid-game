using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBonusFactory :BonusFactory {

		public Bonus CreateBonus ()
		{
			return new PlatformBonus ();
		}
}
