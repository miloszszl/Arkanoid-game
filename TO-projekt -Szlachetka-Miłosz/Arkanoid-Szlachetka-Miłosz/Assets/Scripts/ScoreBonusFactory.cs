using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class ScoreBonusFactory :BonusFactory{

    public Bonus CreateBonus()
	{
        return new ScoreBonus();
	}
}
