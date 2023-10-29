using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateChase : AIState
{
	public AIStateChase(StateAI newAI) : base(newAI)
	{

	}

	public override void UpdateState()
	{
		if (ai.CanSeeTarget())
		{
            if (!ai.enemyInfo.isHit)
            {
				ai.movement.MoveToward(ai.targetTransform.position);
			} else
            {
				ai.movement.Stop();
            }
		}
		else
		{
			ai.movement.Stop();
			ai.ChangeState(ai.patrolState);
		}
	}

	public override void BeginState()
	{
		//INDICATE ATTACK!
	}
}
